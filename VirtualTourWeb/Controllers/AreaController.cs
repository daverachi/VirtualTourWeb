using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualTourWeb.Interfaces;

namespace VirtualTourWeb.Controllers
{
    public class AreaController : Controller
    {
        private readonly IAreaRestService _areaService;
        public AreaController(IAreaRestService areaService)
        {
            _areaService = areaService;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index(int id)
        {
            var area = _areaService.GetAreaAsync(id).Result;
            return PartialView("Index", area);
        }
    }
}