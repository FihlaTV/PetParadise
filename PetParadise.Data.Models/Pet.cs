namespace PetParadise.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Pet
    {
        public Pet()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Range(0, 200)]
        public int Age { get; set; }

        [StringLength(1000)]
        public string AdditionalInfo { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        [Required]
        [ForeignKey("Species")]
        public int? SpeciesId { get; set; }

        public virtual Species Species { get; set; }

        [ForeignKey("Breed")]
        public int? BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
