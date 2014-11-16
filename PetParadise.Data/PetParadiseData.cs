namespace PetParadise.Data
{
    using System;
    using System.Collections.Generic;

    using PetParadise.Data.Repositories;
    using PetParadise.Data.Models;

    public class PetParadiseData : IPetParadiseData
    {
        private IPetParadiseDbContext context;
        private IDictionary<Type, object> repositories;

        public PetParadiseData()
            : this(new PetParadiseDbContext())
        {
        }

        public PetParadiseData(IPetParadiseDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Pet> Pets
        {
            get
            {
                return this.GetRepository<Pet>();
            }
        }

        public IRepository<Species> Species
        {
            get
            {
                return this.GetRepository<Species>();
            }
        }

        public IRepository<Breed> Breeds
        {
            get
            {
                return this.GetRepository<Breed>();
            }
        }

        public IRepository<Reservation> Reservations
        {
            get
            {
                return this.GetRepository<Reservation>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                //if (typeOfModel.IsAssignableFrom(typeof(Student)))
                //{
                //    type = typeof(StudentsRepository);
                //}

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
