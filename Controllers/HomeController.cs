using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Showcase.BLL;
using Showcase.Data;
using Showcase.Models;
using Showcase.Models.ViewModels;
using System.Diagnostics;

namespace Showcase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private ShowcaseManager showcaseManager
        {
            get
            {
                return new ShowcaseManager(_context);
            }
        }

        public ActionResult Net()
        {
            var showcases = GetAllShowcase();
            return View(showcases);
        }

        [HttpGet]
        public JsonResult GetAllShowcases()
        {
            var showcases = GetAllShowcase();

            return Json(showcases);
        }

        [HttpGet("showcase")]
        public List<ShowcaseVM> GetAllShowcase()
        {
            return showcaseManager.GetAllShowcase();
        }

        [HttpGet("showcase/{id}")]
        public ShowcaseVM GetShowcaseByID(int id)
        {
            return showcaseManager.GetShowcaseByID(id);
        }

        public JsonResult HideShowcases(int id)
        {
            if (showcaseManager.HideShowcase(id))
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpDelete("hideshowcase")] 
        public JsonResult HideShowcase(int id)
        {

            if (showcaseManager.HideShowcase(id))
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public JsonResult SaveData([FromBody] ShowcaseVM data)
        {
            try
            {
                showcaseManager.SaveShowcase(data.Name, data.Description, data.isHidden);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { success = false });
            }
            
        }

        [HttpPost("SaveShowcase")]
        public JsonResult SaveShowcase(string name, string description, bool hidden)
        {
            try
            {
                showcaseManager.SaveShowcase(name, description, hidden);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { success = false });
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Angular()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
