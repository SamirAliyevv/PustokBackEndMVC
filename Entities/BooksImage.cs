using System.Reflection.Metadata.Ecma335;

namespace Pustok.Entities
{
    public class BooksImage
    {

        public int Id { get; set; }

        public string ImageUrl { get; set;  }
        public int BooksId { get; set; }
        public Books Books { get; set; }
        public bool? PosterImage { get; set; }

    }
}
