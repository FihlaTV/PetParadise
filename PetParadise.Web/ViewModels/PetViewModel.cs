namespace PetParadise.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using PetParadise.Data.Models;

    public class PetViewModel
    {
        [Required(ErrorMessage="Полето Име е задължително!")]
        [Display(Name="Име")]
        public string Name { get; set; }

        [Display(Name = "Възраст")]
        public int Age { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        [Required]
        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public byte[] Image { get; set; }

        public string ImageContentType { get; set; }

        [StringLength(1000)]
        [Display(Name = "Допълнителна информация")]
        public string AdditionalInfo { get; set; }
    }
}