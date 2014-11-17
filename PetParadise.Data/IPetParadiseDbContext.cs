using PetParadise.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace PetParadise.Data
{
    public interface IPetParadiseDbContext
    {
        IDbSet<Pet> Pets { get; set; }

        IDbSet<Species> Species { get; set; }

        IDbSet<Breed> Breeds { get; set; }

        IDbSet<Reservation> Reservations { get; set; }

        IDbSet<Image> Images { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
