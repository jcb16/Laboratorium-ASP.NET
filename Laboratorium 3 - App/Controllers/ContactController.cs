using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    public class ContactController : Controller
    {
        //lista kontaktów
        static Dictionary<int,Contact> _contacts = new Dictionary<int,Contact>();
        static int id = 1;
        public IActionResult Index()
        {
            return View(_contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Contact model) { 
            if(ModelState.IsValid)
            {
                // dodaj model do bazy lub kolekcji 
                model.ID = id++;
                _contacts.Add(model.ID, model);
                return RedirectToAction("Index");
            }
            return View(); 
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contacts[id]);
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if(ModelState.IsValid)
            {
                _contacts[model.ID] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet] 
        public IActionResult Delete(int id)
        {
            return View(_contacts[id]);
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contacts.Remove(model.ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            return View(_contacts[id]);
        }
    }
}
