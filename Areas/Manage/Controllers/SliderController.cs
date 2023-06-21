using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pustok.Areas.Manage.ViewModels;
using Pustok.DAL;
using Pustok.Entities;
using Pustok.Helpers;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private readonly RelationsBooksShop _context;
        private readonly IWebHostEnvironment _env;
        public SliderController( RelationsBooksShop context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index( int page=1)
        {

            var query= _context.Sliders.AsQueryable();
            return View(PaginatedList<Sliders>.Create(query,page,2));
        }
        public IActionResult Create() {
        
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sliders sliders)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (sliders == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is Required");
            }
          









            sliders.ImageUrl = FileManager.Save(sliders.ImageFile, _env.WebRootPath, "manage/uploads/sliders");


            _context.Sliders.Add(sliders);

            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit( int id)
        {
            Sliders sliders = _context.Sliders.Find(id);

            if (sliders == null)
            {
                return View("error");
            }
            return View(sliders);
        }

        [HttpPost]
        public IActionResult Edit(Sliders sliders)
        {
            if (!ModelState.IsValid)
            {
                return View(sliders);
            }

            Sliders existSliders= _context.Sliders.Find(sliders.Id);

            if (existSliders ==null) 
            { 
                return View("error");
            }
            string removableImageName = null;
         
            _context.SaveChanges();
            if (sliders.ImageFile!= null)
            {
                removableImageName = existSliders.ImageUrl;
                existSliders.ImageUrl = FileManager.Save(sliders.ImageFile, _env.WebRootPath, "manage/uploads/sliders");

            }


          
            existSliders.Id = sliders.Id;
            existSliders.Order = sliders.Order;
            existSliders.ImageUrl = sliders.ImageUrl;
            existSliders.Description = sliders.Description;
            existSliders.Price = sliders.Price;
            existSliders.HeaderTitle = sliders.HeaderTitle;


            _context.SaveChanges();

            if (removableImageName != null)
            {
                FileManager.Delete(_env.WebRootPath, "manage/uploads/sliders", removableImageName );
            }

         
            return RedirectToAction("index");

        }
    }
}
