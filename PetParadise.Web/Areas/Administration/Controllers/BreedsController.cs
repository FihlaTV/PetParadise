using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetParadise.Web.Areas.Administration.Controllers
{
    public class BreedsController : Controller
    {
        // GET: Administration/Breeds
        public ActionResult Index()
        {
            return View();
        }
    }
}