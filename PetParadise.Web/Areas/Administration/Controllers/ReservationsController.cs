namespace PetParadise.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using PetParadise.Data.Models;
    using PetParadise.Data;
    using PetParadise.Web.Areas.Administration.Controllers.Base;

    using Model = PetParadise.Data.Models.Reservation;
    using ViewModel = PetParadise.Web.Areas.Administration.ViewModels.Reservations.ReservationViewModel;
    
    public class ReservationsController : KendoGridAdministrationController
    {
        public ReservationsController(IPetParadiseData data)
            : base(data)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Reservations
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Reservations.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null)
            {
                model.Id = dbModel.Id;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Reservations.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}