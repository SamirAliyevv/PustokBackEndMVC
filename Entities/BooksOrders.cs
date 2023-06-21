namespace Pustok.Entities
{
    public class BooksOrders
    {
        public int BooksId { get; set; }
        public int OrdersId { get; set; }
        public Books Books { get; set; }
        public Orders Orders { get; set; }  
    }
}
