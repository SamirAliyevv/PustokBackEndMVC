namespace Pustok.Entities
{
    public class BooksTags
    {
        public int BooksId { get; set; }
        public int TagsId { get; set; }

        public Books Books { get; set; }
        public Tags Tags { get; set; }

    }
}
