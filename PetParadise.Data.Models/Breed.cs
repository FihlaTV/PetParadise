namespace PetParadise.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Breed
    {
        public Breed()
        {
            this.Pets = new HashSet<Pet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Information { get; set; }

        [Required]
        public int SpeciesId { get; set; }

        public virtual Species Species { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        [InverseProperty("Breed")]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
