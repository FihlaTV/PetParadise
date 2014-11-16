namespace PetParadise.Web.ViewModels.Pets
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using PetParadise.Data.Models;
    using PetParadise.Web.Infrastructure.Mapping;

    public class AddPetViewModel : IMapFrom<Pet>
    {
        [Required]
        [StringLength(70)]
        [Display(Name = "Име")]
        [UIHint("SingleLineText")]
        public string Name { get; set; }

        [Display(Name = "Възраст")]
        [UIHint("NumberCustom")]
        public int? Age { get; set; }

        [Required]
        [Display(Name = "Вид")]
        [UIHint("DropDownList")]
        public int SpeciesId { get; set; }

        public IEnumerable<SelectListItem> Species { get; set; }

        [Display(Name = "Порода")]
        [UIHint("DropDownList")]
        public int BreedId { get; set; }

        public IEnumerable<SelectListItem> Breeds { get; set; }

        [StringLength(1000)]
        [Display(Name = "Допълнителна информация")]
        [UIHint("MultiLineText")]
        public string AdditionalInfo { get; set; }
    }
}