using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok.DAL;
using Pustok.ViewModels;

namespace Pustok.Controllers
{
    public class BookController : Controller
    {
        private readonly RelationsBooksShop  _context;

        public BookController(RelationsBooksShop context)
        {
            _context = context;
        }


        public IActionResult addtobasket(int id)
        {
            var basketstr = Request.Cookies["basket"];
            List<BasketCookiesItemViewModel> cookieitems = null;
           
            if (basketstr == null)
            {
                cookieitems = new List<BasketCookiesItemViewModel>();
              
            }
            else
            {
                cookieitems = JsonConvert.DeserializeObject<List<BasketCookiesItemViewModel>>(basketstr);

            }
            BasketCookiesItemViewModel item = cookieitems.FirstOrDefault(x=>x.BookId==id);
            if (item == null)
            {
                item = new BasketCookiesItemViewModel
                {
                    BookId = id,
                    Count = 1

                };
                cookieitems.Add(item);
            }
            else
            {
                item.Count++;
            }
            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(cookieitems));


            BasketViewmodel basketVM= new BasketViewmodel();
            basketVM.Items = new List<BasketItemViewModel>();

            foreach (var cookieitem in cookieitems)
            {
                BasketItemViewModel items = new BasketItemViewModel()

                {
                    Count = cookieitem.Count,
                    Book=_context.Books.Include(x=>x.BooksImages.Where(x=>x.PosterImage==true)).FirstOrDefault(x=>x.Id==cookieitem.BookId   )

                };
                basketVM.Items.Add(items);
                basketVM.TotalAmount += (items.Book.Percent > 0 ? items.Book.Price * (100 - items.Book.Percent) / 100 : items.Book.Price) * items.Count;

            }


            return PartialView("_BasketPartial",basketVM);

        }
        public IActionResult RemoveBasket(int id)
        {
            var basketstr = HttpContext.Request.Cookies["basket"];
            List<BasketCookiesItemViewModel> cookieitems = null;

            if (basketstr == null)
            {
                cookieitems = new List<BasketCookiesItemViewModel>();

            }
            else
            {
                cookieitems = JsonConvert.DeserializeObject<List<BasketCookiesItemViewModel>>(basketstr);

            }
            var product = cookieitems.FirstOrDefault(x => x.BookId == id);

            if (product != null)
            {
                cookieitems.Remove(product);
            }
            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(cookieitems));


            return RedirectToAction("index","home");
        }

        public IActionResult ShowBasket(int id)
        {
            var datastr = HttpContext.Request.Cookies["basket"];
            var data = JsonConvert.DeserializeObject<List<BasketCookiesItemViewModel>>(datastr);
          

            return Json(data);
        }




    }
}
