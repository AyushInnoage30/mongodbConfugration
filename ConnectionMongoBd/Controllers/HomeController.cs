using Microsoft.AspNetCore.Mvc;

namespace ConnectionMongoBd.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
