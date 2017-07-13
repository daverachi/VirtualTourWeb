using System.Threading.Tasks;
using VirtualTourWeb.Models;

namespace VirtualTourWeb.Interfaces
{
    public interface ITourRestService
    {
        Task<Tour> GetTourAsync(int id);
    }
}
