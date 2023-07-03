using Fiorello_AdminPanel.Areas.Manage.ViewModels;
using Fiorello_AdminPanel.DAL;
using Fiorello_AdminPanel.Entities;
using Fiorello_AdminPanel.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_AdminPanel.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    [Area("manage")]
    public class SliderController:Controller
    {
        private readonly FiorelloDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(FiorelloDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Sliders.AsQueryable();
            return View(PaginatedList<Slider>.Create(query, page, 3));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View(slider);
            }
            if (slider == null)
            {
                return View("_error");
            }
            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image boş qala bilməz..");
                return View(slider);
            }
            if(slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "Fayl ancaq jpg və png formatında ola bilər..");
                return View(slider);
            }
            
            slider.ImageName = FileManager.Save(slider.ImageFile, _env.WebRootPath, "manage/uploads/sliders");
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Slider? slider = _context.Sliders.Find(id);
            if(slider == null)
            {
                return View("_error");
            }
            return View(slider);
        }
        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid) { return View(slider); }
            Slider? existSlider = _context.Sliders.Find(slider.Id);
            if (existSlider == null) return View("_error");
            string? removableImageName = null;
            if(slider.ImageFile != null)
            {
                if(slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Image yalnız 'jpeg' və 'png' formatında ola bilər..");
                    return View(slider);
                }
                removableImageName = existSlider.ImageName;
                existSlider.ImageName = FileManager.Save(slider.ImageFile, _env.WebRootPath, "manage/uploads/sliders");
            }
            existSlider.Title1 = slider.Title1;
            existSlider.Title2 = slider.Title2;
            existSlider.Order = slider.Order;
            existSlider.Description = slider.Description;
            existSlider.BtnTxt = slider.BtnTxt;

            _context.SaveChanges();
            if (removableImageName != null) FileManager.Delete(_env.WebRootPath, "manage/uploads/sliders", removableImageName);
            
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Slider? slider = _context.Sliders.Find(id);
            if (slider == null) return StatusCode(404);
            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return StatusCode(200);
        }
    }
}
