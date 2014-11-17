namespace PetParadise.Web.ViewModels.Pets
{
    using System;
    using System.Linq;

    using PetParadise.Data.Models;
    using PetParadise.Web.Infrastructure.Mapping;

    public class PetDetailsViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string AdditionalInfo { get; set; }

        public string OwnerName { get; set; }

        public string SpeciesName { get; set; }

        public string BreedName { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int ReservationsCount { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Pet, PetDetailsViewModel>()
                .ForMember(m => m.OwnerName, opt => opt.MapFrom(t => t.Owner.UserName))
                .ForMember(m => m.SpeciesName, opt => opt.MapFrom(t => t.Species.Name))
                .ForMember(m => m.BreedName, opt => opt.MapFrom(t => t.Breed.Name))
                .ForMember(m => m.ReservationsCount, opt => opt.MapFrom(t => t.Reservations.Count))
                .ReverseMap();
        }
    }
}