using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using VirtualTourWeb.Services.Rest;

namespace VirtualTourWeb.Unity
{
    public class UnityWebCommon
    {
        public static IUnityContainer GetUnityContainer()
        {
            var helper = new UnityHelper(GetAssembliesToLoad());
            var container = helper.Container;

            container.RegisterType<HttpContextBase, HttpContextWrapper>();
            container.RegisterType<HttpContext>(new InjectionFactory(c => HttpContext.Current));

            container = helper.BuildUnityContainer();
            return container;
        }

        internal static List<Assembly> GetAssembliesToLoad()
        {
            List<Assembly> assembliesToLoad = new List<Assembly>();
            assembliesToLoad.Add(typeof(ClientRestService).Assembly);
            assembliesToLoad.Add(Assembly.GetExecutingAssembly());

            return assembliesToLoad;
        }


    }
    public class UnityHelper
    {
        public List<Assembly> _AssembliesToScan = new List<Assembly>();
        IUnityContainer container = new UnityContainer();

        public UnityHelper(List<Assembly> AssembliesToScan)
        {
            _AssembliesToScan = AssembliesToScan;
        }

        public IUnityContainer Container { get { return container; } }

        public virtual IUnityContainer BuildUnityContainer()
        {
            ConventionConfiguration(container);
            return container;
        }

        private void ConventionConfiguration(IUnityContainer container)
        {
            foreach (var asm in _AssembliesToScan)
            {
                var interfaces = asm.GetInterfaces();

                foreach (var interfaceType in interfaces)
                {
                    var currentInterfaceType = interfaceType;
                    var implementations = asm.GetImplementationsOfInterface(interfaceType);
                    if (implementations.Count > 0)
                    {
                        if (!container.IsRegistered(currentInterfaceType))
                        {
                            container.RegisterType(currentInterfaceType, implementations.ToList().First());
                        }
                    }
                }
            }
        }
    }

    public class PerHttpRequestLifetime : LifetimeManager
    {
        private readonly Guid _key = Guid.NewGuid();

        public override object GetValue()
        {
            if (HttpContext.Current == null) return null; //effectively makes it TransientLifetimeManager
            return HttpContext.Current.Items[_key];
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current == null) return;
            HttpContext.Current.Items[_key] = newValue;
        }

        public override void RemoveValue()
        {
            if (HttpContext.Current == null) return;
            var obj = GetValue();
            HttpContext.Current.Items.Remove(obj);
        }
    }

    public static class AssemblyHelper
    {
        public static IEnumerable<Type> GetInterfaces(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsInterface);
        }

        public static IList<Type> GetImplementationsOfInterface(this Assembly assembly, Type interfaceType)
        {
            var implementations = new List<Type>();

            var concreteTypes = assembly.GetTypes().Where(t =>
                !t.IsInterface &&
                !t.IsAbstract &&
                interfaceType.IsAssignableFrom(t));

            concreteTypes.ToList().ForEach(implementations.Add);

            return implementations;
        }
    }
}