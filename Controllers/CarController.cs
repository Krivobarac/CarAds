using Microsoft.AspNetCore.Mvc;

namespace CarAds.Controllers
{
    public class CarController : Controller
    {
        public IActionResult AddCar()
        {
            return View();
        }
    }
}
