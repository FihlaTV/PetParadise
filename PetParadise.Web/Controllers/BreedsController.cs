using PetParadise.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetParadise.Web.Controllers
{
    public class BreedsController : BaseController
    {
        public BreedsController(IPetParadiseData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}