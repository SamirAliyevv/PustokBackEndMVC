using Pustok.Attributes.CustomValidationAttribute;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok.Entities
{
    public class Sliders
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string HeaderTitle { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Order { get; set; }
        [NotMapped]
        [MaxFileLength(2097152)]
        [CheckFormatImage("image/jpeg", "image/png")]
        public IFormFile ImageFile { get; set; }
            
    }
}
