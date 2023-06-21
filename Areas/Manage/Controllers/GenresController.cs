using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Areas.Manage.ViewModels;
using Pustok.DAL;
using Pustok.Entities;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GenresController : Controller
    {
        private readonly RelationsBooksShop _context;
        public GenresController( RelationsBooksShop context)
        {
            _context = context;
        }
        public IActionResult Index( int page=1,string search=null)
        {
            ViewBag.Search = search;
            var query= _context.Genres.Include(x=>x.Books).AsQueryable();

            if (search != null) query = query.Where(x => x.Name.Contains(search));
            
              
                return View(PaginatedList<Genres>.Create(query,page,2));

             


            

        }   
        public IActionResult Create()
        {


            return View();  
        }

        [HttpPost]
        public IActionResult Create(Genres genre)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

          if (_context.Genres.Any(x=>x.Name==genre.Name))
            {
                ModelState.AddModelError("Name", "Name is already taken");
                return View();
            }

            _context.Genres.Add(genre);    
            _context.SaveChanges();
            return RedirectToAction("index");

        }
       public IActionResult Edit(int id)
        {
            Genres genre = _context.Genres.FirstOrDefault(x=>x.Id==id);
            if (genre == null)
            {
                return RedirectToAction("index");
            }
            return View(genre);
        }

        [HttpPost]  
        public IActionResult Edit(Genres genre)
        {
            if (!ModelState.IsValid)
                return View();

            Genres existGenre = _context.Genres.FirstOrDefault(x => x.Id == genre.Id);


            if (genre.Name != existGenre.Name && _context.Genres.Any(x => x.Name == genre.Name))
            {
                ModelState.AddModelError("Name", "Name is already taken");
                return View();
            }   


            existGenre.Name = genre.Name;
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Genres genre = _context.Genres.Find(id);
            if (genre == null) return StatusCode(404);






            _context.Genres.Remove(genre);
            _context.SaveChanges();


            return RedirectToAction("index");
        }
    }
}
