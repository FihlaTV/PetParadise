using PetParadise.Data;
using PetParadise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetParadise.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IPetParadiseData data)
            : base(data)
        {
        }

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

        public ActionResult Error()
        {
            return View();
        }
    }
}