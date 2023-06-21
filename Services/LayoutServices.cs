using Pustok.Entities;
using Pustok.DAL;
using Pustok.ViewModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Pustok.Services
{
    public class LayoutServices
    {

        private readonly RelationsBooksShop _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutServices(RelationsBooksShop context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

            
        }

        public List<Genres> GetGenres()
        {
            return _context.Genres.ToList(); 
        }
        public Dictionary<string,string> GetSettings()
        {
            return _context.Settings.ToDictionary(x => x.Key,x => x.Value);
            
        }
        public BasketViewmodel GetBasketViewmodel()
        {
            var basketVM =   new BasketViewmodel();
            var basketstr = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
            List<BasketCookiesItemViewModel> cookeItems = null;
            if (basketstr==null)
            {
                cookeItems = new List<BasketCookiesItemViewModel>();

            }
            else
            {
                cookeItems = JsonConvert.DeserializeObject<List<BasketCookiesItemViewModel>>(basketstr);
            }
            basketVM.Items = new List<BasketItemViewModel>();
            foreach (var cookieitem in cookeItems)
            {
                BasketItemViewModel item = new BasketItemViewModel()
                {
                    Count = cookieitem.Count,
                    Book = _context.Books.Include(x => x.BooksImages).FirstOrDefault(x=>x.Id==cookieitem.BookId)

                };
                basketVM.Items.Add(item);
                basketVM.TotalAmount += (item.Book.Percent > 0 ? item.Book.Price * (100 - item.Book.Percent) / 100:item.Book.Price)*item.Count;
            }   


            return basketVM;    
        }


    }
  
}
