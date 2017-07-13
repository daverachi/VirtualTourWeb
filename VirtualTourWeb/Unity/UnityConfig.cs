using System.Web.Mvc;

namespace VirtualTourWeb.Unity
{
    public class UnityConfig
    {
        public static void RegisterUnity()
        {
            var container = UnityWebCommon.GetUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}