namespace PetParadise.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using PetParadise.Data;
    using PetParadise.Data.Models;
    using PetParadise.Web.ViewModels.Pets;
    
    public class PetsController : BaseController
    {
        public PetsController(IPetParadiseData data)
            : base(data)
        {
        }

        [Authorize]
        public ActionResult All()
        {
            var pets = this.Data.Pets
                .All()
                .OrderByDescending(p => p.Name)
                .Project()
                .To<ListPetViewModel>()
                .ToList();

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
                if (pet.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        pet.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        var image = new Image
                        {
                            Contetnt = content,
                            ContentType = pet.UploadedImage.ContentType
                        };

                        this.Data.Images.Add(image);
                        this.Data.SaveChanges();
                        dbPet.ImageId = image.Id;
                    }
                }
                this.Data.Pets.Add(dbPet);
                this.Data.SaveChanges();

                return this.RedirectToAction("All", "Pets");
            }

            return View(pet);
        }
        
        [HttpGet]
        public ActionResult Details(int id)
        {
            var pet = this.Data.Pets.GetById(id);
            if (pet == null)
            {
                throw new HttpException(404, "Pet not found");
            }

            var petDetails = Mapper.Map<PetDetailsViewModel>(pet);

            return View(petDetails);
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

        public ActionResult Image(int id)
        {
            var image = this.Data.Images.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Contetnt, image.ContentType);
        }

        public ActionResult ImageByBreed(string id)
        {
            var breed = this.Data.Breeds.All().FirstOrDefault(b => b.Name == id);
            if (breed == null || breed.ImageId == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.Image((int)breed.ImageId);
        }
    }
}