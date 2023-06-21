using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Pustok.Entities
{
    public class Books
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        public bool StockStatus { get; set; }
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }
        public int GenresId { get; set; }

        public int AuthorsId { get; set; }
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public decimal Percent { get; set; }

        public Authors Authors { get; set; }
        public List<BooksImage> BooksImages { get; set; }
        public Genres Genres { get; set; }
        

        public List<BooksOrders> BooksOrders { get; set; }
        public List<BooksTags> BooksTags { get; set; }

    }

}
