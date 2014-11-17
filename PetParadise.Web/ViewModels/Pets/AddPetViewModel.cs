namespace PetParadise.Web.ViewModels.Pets
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PetParadise.Data.Models;
    using PetParadise.Web.Infrastructure.Mapping;
    using AutoMapper;

    public class AddPetViewModel : IMapFrom<Pet>, IHaveCustomMappings
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

        [Display(Name = "Снимка")]
        public HttpPostedFileBase UploadedImage { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Pet, AddPetViewModel>()
                .ForMember(m => m.UploadedImage, opt => opt.MapFrom(t => t.Image))
                .ReverseMap();
        }
    }
}