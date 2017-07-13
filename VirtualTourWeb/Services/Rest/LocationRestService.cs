using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using VirtualTourWeb.Interfaces;
using VirtualTourWeb.Models;

namespace VirtualTourWeb.Services.Rest
{
    public class LocationRestService : BaseRestService, ILocationRestService
    {
        public async Task<Location> GetLocationAsync(int id)
        {
            var uri = BuildBaseApiURI(id);
            var location = new Location();
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    location = JsonConvert.DeserializeObject<Location>(response.Content.ReadAsStringAsync().Result);
                }
                return location;
            }
        }
    }
}