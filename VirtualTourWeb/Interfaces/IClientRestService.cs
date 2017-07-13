using System.Threading.Tasks;
using VirtualTourWeb.Models;

namespace VirtualTourWeb.Interfaces
{
    public interface IClientRestService
    {
        Task<Client> GetClientAsync();
    }
}
