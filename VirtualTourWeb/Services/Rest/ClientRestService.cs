using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using VirtualTourWeb.Interfaces;
using VirtualTourWeb.Models;

namespace VirtualTourWeb.Services.Rest
{
    public class ClientRestService : BaseRestService, IClientRestService
    {
        public async Task<Client> GetClientAsync()
        {
            var uri = BuildBaseApiURI();
            var client = new Client();
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    client =  JsonConvert.DeserializeObject<Client>(response.Content.ReadAsStringAsync().Result);
                }
                return client;
            }
        }
    }
}