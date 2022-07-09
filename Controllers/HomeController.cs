using Microsoft.AspNetCore.Mvc;

namespace CarAds.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(Person person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Attendance.AddAttendant(person);
        //        TempData["FirstName"] = person.FirstName + " " + person.LastName;
        //        return RedirectToAction("Index");
        //    }
        //    else { return View(); }
        //}

        public IActionResult Error404()
        {
            return View();
        }
    }
}
