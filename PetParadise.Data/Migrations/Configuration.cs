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

    internal sealed class Configuration : DbMigrationsConfiguration<PetParadiseDbContext>
    {
        private UserManager<User> userManager;
        private IList<string> dogBreeds = new string[] { "���������� ������", "��������", "������ �������", 
            "������ ��������", "����� �������", "�����", "������", "�����", "����������", "������" };
        private IList<string> speciesTypes = new string[] { "����", "�����", "����", "�������", "����������", "�������", "��������" };

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
            pets.Add(new Pet { 
                Name = "����",
                Age = 3,
                AdditionalInfo = "���� ����",
                BreedId = context.Breeds.FirstOrDefault(b => b.Name == this.dogBreeds[2]).Id,
                SpeciesId = context.Species.FirstOrDefault(c => c.Name == this.speciesTypes[0]).Id,
                OwnerId = context.Users.FirstOrDefault(u => u.UserName == "����").Id
            });

            pets.Add(new Pet
            {
                Name = "����",
                Age = 2,
                AdditionalInfo = "����� ������",
                BreedId = context.Breeds.FirstOrDefault(b => b.Name == this.dogBreeds[0]).Id,
                SpeciesId = context.Species.FirstOrDefault(c => c.Name == this.speciesTypes[0]).Id,
                OwnerId = context.Users.FirstOrDefault(u => u.UserName == "�����").Id
            });

            pets.Add(new Pet
            {
                Name = "����",
                Age = 6,
                AdditionalInfo = "����� ��������",
                SpeciesId = context.Species.FirstOrDefault(c => c.Name == this.speciesTypes[1]).Id,
                OwnerId = context.Users.FirstOrDefault(u => u.UserName == "�����").Id
            });
        }

        private void SeedBreeds(PetParadiseDbContext context)
        {
            if (context.Breeds.Any())
            {
                return;
            }

            

            var dogSpeciesId = context.Species.FirstOrDefault(s => s.Name == "����").Id;
            foreach (var item in dogBreeds)
            {
                var breed = new Breed {
                    Name = item,
                    SpeciesId = dogSpeciesId,
                };
            }

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

            var userPesho = new User
                {
                    Email = "pesho@abv.bg",
                    UserName = "����"
                };

            this.userManager.Create(userPesho, "123456");

            var userGosho = new User
            {
                Email = "gosho@abv.bg",
                UserName = "�����"
            };

            this.userManager.Create(userGosho, "123456");

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
            context.SaveChanges();
        }
    }
}
