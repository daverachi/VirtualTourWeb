using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualTourWeb.Interfaces;

namespace VirtualTourWeb.Controllers
{
    public class VTController : Controller
    {
        private readonly IAreaRestService _areaService;
        private readonly IClientRestService _clientService;
        private readonly ILocationRestService _locationService;
        private readonly ITourRestService _tourService;
        public VTController(
              IAreaRestService areaService
            , IClientRestService clientService
            , ILocationRestService locationService
            , ITourRestService tourService)
        {
            _areaService = areaService;
            _clientService = clientService;
            _locationService = locationService;
            _tourService = tourService;
        }

        public ActionResult Index()
        {
            var client = _clientService.GetClientAsync().Result;
            return View(client);
        }
        public ActionResult Location(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "VT");
            }
            var location = _locationService.GetLocationAsync(id.Value).Result;
            return View("Location", location);
        }

        public ActionResult Area(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "VT");
            }
            var area = _areaService.GetAreaAsync(id.Value).Result;
            return View("Area", area);
        }

        public ActionResult Tour(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "VT");
            }
            var tour = _tourService.GetTourAsync(id.Value).Result;
            return View("Tour", tour);
        }
    }
}