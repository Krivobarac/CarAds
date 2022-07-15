using CarAds.Managers;
using Microsoft.AspNetCore.Mvc;

namespace CarAds.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarManager _carManager;

        public HomeController(CarManager carManager)
        {
            _carManager = carManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}
