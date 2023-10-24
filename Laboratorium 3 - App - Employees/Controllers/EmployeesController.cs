using Laboratorium_3___App___Employees.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    public class EmployeesController : Controller
    {
        //lista pracowników
        static Dictionary<int,Employees> _employees = new Dictionary<int,Employees>();
        static int id = 1;
        public IActionResult Index()
        {
            return View(_employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Employees model) { 
            if(ModelState.IsValid)
            {
                // dodaj model do bazy lub kolekcji 
                model.ID = id++;
                _employees.Add(model.ID, model);
                return RedirectToAction("Index");
            }
            return View(); 
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_employees[id]);
        }

        [HttpPost]
        public IActionResult Update(Employees model)
        {
            if(ModelState.IsValid)
            {
                _employees[model.ID] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet] 
        public IActionResult Delete(int id)
        {
            return View(_employees[id]);
        }

        [HttpPost]
        public IActionResult Delete(Employees model)
        {
            _employees.Remove(model.ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            return View(_employees[id]);
        }
    }
}
