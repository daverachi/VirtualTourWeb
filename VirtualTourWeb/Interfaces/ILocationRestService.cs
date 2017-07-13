using System.Threading.Tasks;
using VirtualTourWeb.Models;

namespace VirtualTourWeb.Interfaces
{
    public interface ILocationRestService
    {
        Task<Location> GetLocationAsync(int id);
    }
}
