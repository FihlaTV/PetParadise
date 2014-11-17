namespace PetParadise.Web.ViewModels.Pets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;

    using PetParadise.Data.Models;
    using PetParadise.Web.Infrastructure.Mapping;

    public class ListPetViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public string SpeciesName { get; set; }

        public string BreedName { get; set; }

        public string AdditionalInfo { get; set; }

        public string OwnerName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Pet, ListPetViewModel>()
                .ForMember(m => m.SpeciesName, opt => opt.MapFrom(t => t.Species.Name))
                .ForMember(m => m.BreedName, opt => opt.MapFrom(t => t.Breed.Name))
                .ForMember(m => m.OwnerName, opt => opt.MapFrom(t => t.Owner.UserName))
                .ReverseMap();
        }
    }
}