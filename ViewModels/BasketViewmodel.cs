namespace Pustok.ViewModels
{
    public class BasketViewmodel
    {
        public List<BasketItemViewModel> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public int BookId { get; internal set; }
    }
}
