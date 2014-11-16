namespace PetParadise.Web.Controllers
{
    using PetParadise.Data;
    using PetParadise.Data.Models;
    using PetParadise.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    public class PetsController : Controller
    {
        private IPetParadiseData data;

        public PetsController()
        {
            this.data = new PetParadiseData();
        }

        public ActionResult All()
        {
            // TODO: Extract PetViewModel!!!
            var pets = data.Pets.All();
            return View(pets);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Pet model)
        {
            model.BreedId = this.data.Breeds.All().Take(1).ToList()[0].Id;
            model.OwnerId = this.User.Identity.GetUserId();

            // TODO: Add InputPetViewModel
            if (ModelState.IsValid)
            {
                this.data.Pets.Add(model);
                return this.RedirectToAction("Index", "Pet");
            }

            return View(model);
        }
    }
}