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
            //var kuche = new Pet();
            //var breed = new Breed();
            //breed.Name = "Хъски";
            //kuche.Breed = breed;
            //kuche.Age = 10;
            //this.data.Breeds.Add(breed);
            //this.data.Pets.Add(kuche);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Тук ще намерите повече информация относно нас и грижата, която полагаме за животинчетата ви.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "За повече контакти търсете разклонители.";

            return View();
        }
    }
}