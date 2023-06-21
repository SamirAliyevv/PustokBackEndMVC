namespace Pustok.Entities
{
    public class Orders
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public DateTime CreatedOred { get; set; }

        public List<BooksOrders> BooksOrders { get; }
    }
}
