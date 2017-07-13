namespace VirtualTourWeb.Helper
{
    public class ConfigurationManager
    {
        public static ConfigurationHelper Configuration;

        static ConfigurationManager()
        {
            Configuration = new ConfigurationHelper();
        }
    }

    public class ConfigurationHelper
    {
        private const string _apiEndpoint = "VirtualTourCore_API";
        public string VirtualTourCore_API
        {
            get
            {
                string result = System.Configuration.ConfigurationManager.AppSettings[_apiEndpoint];
                return result;
            }
        }

        private const string _clientAccessCode = "ClientAccessCode";
        public string ClientAccessCode
        {
            get
            {
                string result = System.Configuration.ConfigurationManager.AppSettings[_clientAccessCode];
                return result;
            }
        }
    }
}