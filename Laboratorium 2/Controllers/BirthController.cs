using Laboratorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BirthForm()
        {
            return View();
        }

        public IActionResult ResultBirth(Birth model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }

            return View(model);
        }

    }
}
