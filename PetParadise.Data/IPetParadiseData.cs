namespace PetParadise.Data
{
    using PetParadise.Data.Models;
    using PetParadise.Data.Repositories;

    public interface IPetParadiseData
    {
        IRepository<Pet> Pets { get; }

        IRepository<Species> Species  { get; }

        IRepository<Breed> Breeds { get; }

        IRepository<Reservation> Reservations { get; }

        IRepository<Image> Images { get; }

        IRepository<User> Users { get; }

        void SaveChanges();
    }
}
