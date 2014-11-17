namespace PetParadise.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using PetParadise.Common;
    using PetParadise.Data.Models;
    using System.IO;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<PetParadiseDbContext>
    {
        private UserManager<User> userManager;
        private IList<string> dogBreeds = new string[] { "Йоркширски териер", "Чихуахуа", "Немска овчарка", 
            "Голдън ретривър", "Кокер шпаниол", "Дакел", "Самоед", "Бийгъл", "Далматинец", "Булдог" };
        private IList<string> dogBreedPictures = new string[] { "yorki.jpg", "chihuahua.jpg", "nemska-ovcharka.jpg", 
            "golden-retriever.jpeg", "koker.jpg", "dakel.jpg", "samoyed.jpg", "bigal.jpg", "dalmatin.jpg", "bulldog.jpg" };
        private IList<string> speciesTypes = new string[] { "Куче", "Котка", "Заек", "Хамстер", "Костенурка", "Папагал", "Хамелеон" };

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Set this to false in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PetParadiseDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedSpecies(context);
            this.SeedBreeds(context);
            this.SeedPets(context);

        }

        private void SeedPets(PetParadiseDbContext context)
        {
            if (context.Pets.Any())
            {
                return;
            }

            var pets = new List<Pet>();

            var breedName = this.dogBreeds[2];
            var speciesName = this.speciesTypes[0];
            var petToAdd = new Pet
            {
                Name = "Шаро",
                Age = 3,
                AdditionalInfo = "Хапе лошо",
                BreedId = context.Breeds.FirstOrDefault(b => b.Name == breedName).Id,
                SpeciesId = context.Species.FirstOrDefault(c => c.Name == speciesName).Id,
                OwnerId = context.Users.FirstOrDefault(u => u.UserName == "Administrator").Id
            };
            pets.Add(petToAdd);

            breedName = this.dogBreeds[0];
            speciesName = this.speciesTypes[0];
            petToAdd = new Pet
            {
                Name = "Сиси",
                Age = 2,
                AdditionalInfo = "Много сладка",
                BreedId = context.Breeds.FirstOrDefault(b => b.Name == breedName).Id,
                SpeciesId = context.Species.FirstOrDefault(c => c.Name == speciesName).Id,
                OwnerId = context.Users.FirstOrDefault(u => u.UserName == "Administrator").Id
            };
            pets.Add(petToAdd);

            speciesName = this.speciesTypes[1];
            petToAdd = new Pet
            {
                Name = "Кити",
                Age = 6,
                AdditionalInfo = "Много гальовна",
                SpeciesId = context.Species.FirstOrDefault(c => c.Name == speciesName).Id,
                OwnerId = context.Users.FirstOrDefault(u => u.UserName == "Administrator").Id
            };
            pets.Add(petToAdd);

            foreach (var pet in pets)
            {
                context.Pets.Add(pet);
            }

            context.SaveChanges();
        }

        private void SeedBreeds(PetParadiseDbContext context)
        {
            if (context.Breeds.Any())
            {
                return;
            }

            var dogSpeciesId = context.Species.FirstOrDefault(s => s.Name == "Куче").Id;
            for (int i = 0; i < this.dogBreeds.Count; i++)
            {
                var breed = new Breed
                {
                    Name = this.dogBreeds[i],
                    SpeciesId = dogSpeciesId,
                    Image = this.GetSampleImage(this.dogBreedPictures[i])
                };

                context.Breeds.Add(breed);
            }

            var catBreed = new Breed {
                Name = "Сиамска",
                SpeciesId = context.Species.FirstOrDefault(s => s.Name == "Котка").Id,
                Information = "Сиамските котки са умни, общителни, обичат да са сред хора и силно се привързват към тях. Твърди се, че по характер приличат изключително на стопанина си. Тези котки са известни с голямата си игривост дори и като възрастни и със силното си мяукане, с което привличат вниманието към себе си, тъй като са много взискателни и имат нужда от ангажираността на стопаните си. Също така те са изключително паметливи и умеят да се отблагодаряват за всяка добра дума или жест на стопанина си.",
                Image = this.GetSampleImage("siamska.jpg")
            };

            context.Breeds.Add(catBreed);

            context.SaveChanges();
        }

        private void SeedSpecies(PetParadiseDbContext context)
        {
            if (context.Species.Any())
            {
                return;
            }

            foreach (var item in speciesTypes)
            {
                var species = new Species { 
                    Name = item
                };

                context.Species.Add(species);
            }

            context.SaveChanges();
        }

        private void SeedUsers(PetParadiseDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            //var userPesho = new User
            //    {
            //        Email = "peshoto@abv.bg",
            //        UserName = "Пешо"
            //    };
            //this.userManager.Create(userPesho, "123456");
            //this.userManager.AddToRole(userPesho.Id, GlobalConstants.UserRole);

            //var userGosho = new User
            //{
            //    Email = "goshoto@abv.bg",
            //    UserName = "Гошко"
            //};
            //this.userManager.Create(userGosho, "123456");
            //this.userManager.AddToRole(userGosho.Id, GlobalConstants.UserRole);

            var adminUser = new User
            {
                Email = "admin@ad.min",
                UserName = "Administrator"
            };
            this.userManager.Create(adminUser, "123456");
            this.userManager.AddToRole(adminUser.Id, GlobalConstants.AdminRole);
        }

        private void SeedRoles(PetParadiseDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.UserRole));
            context.SaveChanges();
        }

        private Image GetSampleImage(string fileName)
        {
            var directory = AssemblyHelpers.GetDirectoryForAssembyl(Assembly.GetExecutingAssembly());
            var file = File.ReadAllBytes(directory + "/../../Migrations/Imgs/" + fileName);
            var image = new Image
            {
                Contetnt = file,
                ContentType = "image/JPEG"
            };

            return image;
        }
    }
}
