namespace PetParadise.Web.Areas.Administration.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using PetParadise.Data.Models;
    using PetParadise.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class ReservationViewModel : IMapFrom<Reservation>
    {
        public Guid? Id { get; set; }

        [Required]
        [Display(Name = "Начална дата")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Крайна дата")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Коментар")]
        [StringLength(1000)]
        public string Comments { get; set; }

    }
}