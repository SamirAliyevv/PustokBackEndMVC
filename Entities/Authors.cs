using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok.Entities
{
    public class Authors
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(70)]
        public string FullName { get; set; }
        public List<Books> Books { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string ImageUrl { get; set; }

    }
}
