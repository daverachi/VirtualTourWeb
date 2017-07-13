using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualTourWeb.Interfaces;

namespace VirtualTourWeb.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourRestService _tourService;
        public TourController(ITourRestService tourService)
        {
            _tourService = tourService;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index(int id)
        {
            var tour = _tourService.GetTourAsync(id).Result;
            return PartialView("Index", tour);
        }
    }
}