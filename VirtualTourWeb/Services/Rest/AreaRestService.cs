using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using VirtualTourWeb.Interfaces;
using VirtualTourWeb.Models;

namespace VirtualTourWeb.Services.Rest
{
    public class AreaRestService : BaseRestService, IAreaRestService
    {
        public async Task<Area> GetAreaAsync(int id)
        {
            var uri = BuildBaseApiURI(id);
            var area = new Area();
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    area = JsonConvert.DeserializeObject<Area>(response.Content.ReadAsStringAsync().Result);
                }
                return area;
            }
        }
    }
}