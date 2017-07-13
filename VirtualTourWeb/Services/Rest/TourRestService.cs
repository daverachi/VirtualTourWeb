using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using VirtualTourWeb.Interfaces;
using VirtualTourWeb.Models;

namespace VirtualTourWeb.Services.Rest
{
    public class TourRestService : BaseRestService, ITourRestService
    {
        public async Task<Tour> GetTourAsync(int id)
        {
            var uri = BuildBaseApiURI(id);
            var tour = new Tour();
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    tour = JsonConvert.DeserializeObject<Tour>(response.Content.ReadAsStringAsync().Result);
                }
                return tour;
            }
        }
    }
}