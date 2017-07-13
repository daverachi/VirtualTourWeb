using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualTourWeb.Interfaces;

namespace VirtualTourWeb.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRestService _locationService;
        public LocationController(ILocationRestService locationService)
        {
            _locationService = locationService;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index(int id)
        {
            var location = _locationService.GetLocationAsync(id).Result;
            return PartialView("Index", location);
        }
    }
}