namespace PetParadise.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using PetParadise.Data.Migrations;
    using PetParadise.Data.Models;

    public class PetParadiseDbContext : IdentityDbContext<User>, IPetParadiseDbContext
    {
        public PetParadiseDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PetParadiseDbContext, Configuration>());
        }

        public static PetParadiseDbContext Create()
        {
            return new PetParadiseDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                        .HasRequired(p => p.Species)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pet>()
                        .HasOptional(p => p.Breed)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Pet> Pets { get; set; }

        public IDbSet<Species> Species { get; set; }

        public IDbSet<Breed> Breeds { get; set; }

        public IDbSet<Reservation> Reservations { get; set; }

        public IDbSet<Image> Images { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
