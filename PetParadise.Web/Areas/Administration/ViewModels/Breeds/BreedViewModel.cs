namespace PetParadise.Web.Areas.Administration.ViewModels.Breeds
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class BreedViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Information { get; set; }

        [Required]
        public string SpeciesId { get; set; }
    }
}