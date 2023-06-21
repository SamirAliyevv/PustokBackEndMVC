using System.ComponentModel.DataAnnotations;

namespace Pustok.Entities
{
    public class Genres
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public List<Books> Books { get; set; }
    }
}
