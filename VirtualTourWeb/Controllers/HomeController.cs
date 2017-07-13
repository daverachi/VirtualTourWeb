using System.Web.Mvc;
using VirtualTourWeb.Interfaces;

namespace VirtualTourWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRestService _clientService;
        public HomeController(IClientRestService clientService)
        {
            _clientService = clientService;
        }
        public ActionResult Index()
        {
            var client = _clientService.GetClientAsync().Result;
            return View(client);
        }
        public ActionResult GetMainNav()
        {
            var client = _clientService.GetClientAsync().Result;
            return PartialView("_MainNavigation", client);
        }
        public ActionResult About()
        {
            var client = _clientService.GetClientAsync().Result;
            return View(client);
        }

        public ActionResult Contact()
        {
            var client = _clientService.GetClientAsync().Result;
            return View(client);
        }
    }
}