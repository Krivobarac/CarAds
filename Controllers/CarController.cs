using CarAds.DTOs;
using CarAds.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarAds.Controllers
{
    public class CarController : Controller
    {
        private readonly CarManager _carManager;

        public CarController(CarManager carManager)
        {
            _carManager = carManager;
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(CarDTO car)
        {
            if (ModelState.IsValid)
            {
                _carManager.AddCar(car);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult<List<SelectListItem>> FillModels(int BrandId)
        {
            return _carManager.GetModels(BrandId);
        }

        public ActionResult<CarDTO> GetCar(int carId)
        {
            return _carManager.GetCar(carId);
        }

        public ActionResult<bool> DeleteCar(int carId)
        {
            return _carManager.DeleteCar(carId);
        }
    }
}
