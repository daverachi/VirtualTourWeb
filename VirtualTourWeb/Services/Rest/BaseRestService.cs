using System;
using VirtualTourWeb.Helper;

namespace VirtualTourWeb.Services.Rest
{
    public class BaseRestService
    {
        private readonly string uri = ConfigurationManager.Configuration.VirtualTourCore_API;
        private readonly string clientAccessCode = ConfigurationManager.Configuration.ClientAccessCode;
        public string BuildBaseApiURI(int? id = null)
        {
            var targetURI = string.Format("{0}/api/{1}", uri, clientAccessCode);
            var extendedURI = string.Empty;
            Type restService = this.GetType();
            if (restService == typeof(ClientRestService))
            {
                extendedURI = "{0}/clientApi";
                if (id != null)
                {
                    extendedURI = string.Format("{0}/{1}", extendedURI, id);
                }
            }
            else if(restService == typeof(TourRestService))
            {
                extendedURI = "{0}/tourApi";
                if(id != null)
                {
                    extendedURI = string.Format("{0}/{1}", extendedURI, id);
                }
            }
            else if (restService == typeof(AreaRestService))
            {
                extendedURI = "{0}/areaApi";
                if (id != null)
                {
                    extendedURI = string.Format("{0}/{1}", extendedURI, id);
                }
            }
            else if (restService == typeof(AreaRestService))
            {
                extendedURI = "{0}/locationApi";
                if (id != null)
                {
                    extendedURI = string.Format("{0}/{1}", extendedURI, id);
                }
            }
            if (!string.IsNullOrWhiteSpace(extendedURI))
            {
                targetURI = string.Format(extendedURI, targetURI);
            }
            return targetURI;
        }
    }
}