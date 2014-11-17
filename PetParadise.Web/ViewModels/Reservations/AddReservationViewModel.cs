namespace PetParadise.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using PetParadise.Data.Models;
    using PetParadise.Data.Models.Validators;
    using PetParadise.Web.Infrastructure.Mapping;

    public class AddReservationViewModel :IMapFrom<Reservation>
    {
        [Required]
        [Display(Name = "Начална дата")]
        [DateAttribute]
        [UIHint("DateTime")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Крайна дата")]
        [DateAttribute]
        [UIHint("DateTime")]
        public DateTime EndDate { get; set; }

        [StringLength(1000)]
        [Display(Name = "Допълнителна информация")]
        [UIHint("MultiLineText")]
        public string Comments { get; set; }

        [Required]
        [Display(Name = "Любимец")]
        [UIHint("DropDownList")]
        public int PetId { get; set; }

        public IEnumerable<SelectListItem> Pets { get; set; }
    }
}