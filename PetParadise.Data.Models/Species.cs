namespace PetParadise.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Species
    {
        public Species()
        {
            this.Breeds = new HashSet<Breed>();
            this.Pets = new HashSet<Pet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength=3)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Information { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }

        [InverseProperty("Species")]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
