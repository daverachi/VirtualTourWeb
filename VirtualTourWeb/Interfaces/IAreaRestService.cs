using System.Threading.Tasks;
using VirtualTourWeb.Models;

namespace VirtualTourWeb.Interfaces
{
    public interface IAreaRestService
    {
        Task<Area> GetAreaAsync(int id);
    }
}
