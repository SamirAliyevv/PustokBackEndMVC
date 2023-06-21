using System.ComponentModel.DataAnnotations;

namespace Pustok.Entities
{
    public class Settings
    {
        [Key]
        public string Key { get; set; }
        [Required]
        [MaxLength(100)]
        public string Value { get; set; }
    }
}
