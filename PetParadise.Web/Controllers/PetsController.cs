namespace PetParadise.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using PetParadise.Data;
    using PetParadise.Web.ViewModels.Pets;
    using AutoMapper;
    using PetParadise.Data.Models;


    public class PetsController : BaseController
    {
        public PetsController(IPetParadiseData data)
            : base(data)
        {
        }

        public ActionResult All()
        {
            var pets = this.Data.Pets.All();
            return View(pets);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            var species = this.Data
                .Species
                .All()
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();

            var addTicketViewModel = new AddPetViewModel
            {
                Species = species,
                Breeds = this.GetBreeds(int.Parse(species[0].Value))
            };

            return View(addTicketViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddPetViewModel pet)
        {
            if (pet != null && ModelState.IsValid)
            {
                var dbPet = Mapper.Map<Pet>(pet);
                dbPet.OwnerId = this.UserProfile.Id;

                this.Data.Pets.Add(dbPet);
                this.Data.SaveChanges();

                return this.RedirectToAction("All", "Pets");
            }

            return View(pet);
        }
        
        [NonAction]
        private IEnumerable<SelectListItem> GetBreeds(int speciesId)
        {
            var breeds = this.Data.Breeds
                .All()
                .Where(b => b.SpeciesId == speciesId)
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Name
                });

            return breeds;
        }

        public ActionResult GetBreedsJson(int id)
        {
            var breeds = this.GetBreeds(id);
            return Json(breeds, JsonRequestBehavior.AllowGet);
        }
    }
}