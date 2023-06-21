using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.ViewModels;
using Pustok.Entities;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {

        private readonly RelationsBooksShop _context;
        public HomeController(RelationsBooksShop context)
        {
            _context = context;

        }



        public IActionResult Index()
        {


            IndexPage indexPage = new IndexPage
            {
                Books = _context.Books.Include(x => x.BooksImages).Include(x => x.Authors).Include(x => x.BooksTags).ToList(),
                Sliders = _context.Sliders.ToList(),
                Features = _context.Features.ToList(),
                FeaturedBooks = _context.Books.Include(x => x.Authors).Include(x => x.BooksImages.Where(x => x.PosterImage != null))
                .Where(x => x.IsFeatured).Take(20).ToList(),

                NewBooks = _context.Books.Include(x => x.Authors).Include(x => x.BooksImages.Where(x => x.PosterImage != null))
                .Where(x => x.IsNew).Take(20).ToList(),































                DiscountedBooks = _context.Books.Include(x => x.Authors).Include(x => x.BooksImages.Where(x => x.PosterImage != null))
                .Where(x => x.Percent>0).Take(20).ToList()



            };
            
            return View(indexPage);


        }
       

    }
}
