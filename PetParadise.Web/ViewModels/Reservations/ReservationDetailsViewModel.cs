namespace PetParadise.Web.ViewModels.Reservations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using PetParadise.Data.Models;
    using PetParadise.Web.Infrastructure.Mapping;

    public class ReservationDetailsViewModel : IMapFrom<Reservation>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [Display(Name = "Начална дата")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Крайна дата")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Бележки")]
        public string Comments { get; set; }

        [Display(Name = "Име на животното")]
        public string PetName { get; set; }

        [Display(Name = "Собственик")]
        public string PetOwner { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Reservation, ReservationDetailsViewModel>()
                .ForMember(m => m.PetName, opt => opt.MapFrom(p => p.Pet.Name))
                .ForMember(m => m.PetOwner, opt => opt.MapFrom(p => p.Pet.Owner.UserName))
                .ReverseMap();
        }
    }
}