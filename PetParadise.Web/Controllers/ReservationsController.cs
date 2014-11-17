namespace PetParadise.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using PetParadise.Data;

    public class ReservationsController : BaseController
    {
        public ReservationsController(IPetParadiseData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}