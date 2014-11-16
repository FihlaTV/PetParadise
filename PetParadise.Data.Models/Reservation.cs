namespace PetParadise.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using PetParadise.Data.Models.Validators;

    public class Reservation
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [DateAttribute]
        public DateTime StartDate { get; set; }

        [Required]
        [DateAttribute]
        public DateTime EndDate { get; set; }

        [StringLength(1000)]
        public string Comments { get; set; }

        [Required]
        public int PetId { get; set; }
                
        public virtual Pet Pet { get; set; }
    }
}
