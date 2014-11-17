namespace PetParadise.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public Image()
        {
            this.Pets = new HashSet<Pet>();
            this.Breeds = new HashSet<Breed>();
        }

        [Key]
        public int Id { get; set; }

        public byte[] Contetnt { get; set; }

        public string ContentType { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public ICollection<Breed> Breeds { get; set; }
    }
}
