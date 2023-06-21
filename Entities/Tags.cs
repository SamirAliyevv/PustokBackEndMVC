namespace Pustok.Entities
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BooksTags> BooksTags { get; set; }
    }
}
