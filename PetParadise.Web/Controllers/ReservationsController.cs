namespace PetParadise.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using PetParadise.Data;
    using PetParadise.Web.ViewModels.Reservations;
    using PetParadise.Data.Models;

    public class ReservationsController : BaseController
    {
        public ReservationsController(IPetParadiseData data)
            : base(data)
        {
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var pets = this.Data.Pets
                .All()
                .Where(p => p.OwnerId == this.UserProfile.Id)
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
                .ToList();

            var model = new AddReservationViewModel {
                Pets = pets
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddReservationViewModel reservation)
        {
            if (reservation != null && ModelState.IsValid)
            {
                var dbReservation = Mapper.Map<Reservation>(reservation);
                
                this.Data.Reservations.Add(dbReservation);
                this.Data.SaveChanges();

                return this.RedirectToAction("MyReservations", "Reservations");
            }

            return View(reservation);
        }

        public ActionResult Details(Guid id)
        {
            var reservation = this.Data.Reservations.GetById(id);
            if (reservation == null)
            {
                throw new HttpException(404, "Pet not found");
            }

            var reservationDetails = Mapper.Map<ReservationDetailsViewModel>(reservation);

            return View(reservationDetails);
        }

        [Authorize]
        public ActionResult MyReservations()
        {
            var reservations = this.Data.Reservations
                .All()
                .Where(r => r.Pet.Owner.UserName == this.UserProfile.UserName)
                .Project()
                .To<ReservationDetailsViewModel>()
                .ToList();

            return View(reservations);
        }
    }
}