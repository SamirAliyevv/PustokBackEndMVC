using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Entities;
using Pustok.DAL;
using Pustok.Areas.Manage.ViewModels;
using Pustok.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Humanizer.Localisation;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AuthorController : Controller
    {
        private readonly RelationsBooksShop _context ;
        private readonly IWebHostEnvironment _environment;


        public AuthorController( RelationsBooksShop context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public IActionResult Index( int page=1)
        {

            var query = _context.Authors.Include(x=>x.Books);
      
            return View(PaginatedList<Authors>.Create(query,page,2));
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Authors authors)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (authors == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is Required");
            }
            if (authors.ImageFile.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2mb");
                return View();


            }
            if (authors.ImageFile.ContentType != "image/jpeg" && authors.ImageFile.ContentType != "image/png")
            {

                ModelState.AddModelError("ImageFile", "ImageFile must be .jpg,.jpeg or .png");
                return View();
            }

            authors.ImageUrl = FileManager.Save(authors.ImageFile, _environment.WebRootPath, "manage/uploads/authors");




            _context.Authors.Add(authors);    
            _context.SaveChanges();

            return RedirectToAction("index");
        }



        public IActionResult Edit(int id)
        {
            Authors authors =_context.Authors.Find(id);  
            if (authors == null)
            {
                return View("error");
            }

            return View(authors);
        }

        [HttpPost]
        public IActionResult Edit(Authors authors)
        {
          
            if (!ModelState.IsValid)
            {
                return View();
            }
            Authors existauthors = _context.Authors.Find(authors.Id);
            if (authors == null)
            {
                return View("error");   
            }
            existauthors.FullName = authors.FullName;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Authors authors = _context.Authors.Include(x=>x.Books).FirstOrDefault(x=>x.Id == x.Id);

            if (authors == null)
            {
                return View("error");
            }
            return View(authors);
        }

        [HttpPost]
        public IActionResult Delete(Authors authors)
        {
            Authors existauthors = _context.Authors.Find(authors.Id);
            if (existauthors==null)
            {
                return View("error");
            }
            _context.Authors.Remove(existauthors);
            _context.SaveChanges(); 

            return RedirectToAction("index");

        }
    }
}
