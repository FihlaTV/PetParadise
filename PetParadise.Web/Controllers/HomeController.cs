using PetParadise.Data;
using PetParadise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetParadise.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPetParadiseData data;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "За нас.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакти.";

            return View();
        }
    }
}