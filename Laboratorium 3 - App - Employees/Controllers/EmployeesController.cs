using Laboratorium_3___App___Employees.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium_3___App.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmployeesController : Controller
    {
        //lista pracowników
        

        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_employeesService.FindAll());
        }

        public IActionResult PagedIndex(int page = 1, int size = 5)
        {
            if (size < 2)
            {
                return BadRequest();
            }
            return View(_employeesService.FindPage(page, size));
        }


        [HttpGet]
        public IActionResult Create()
        {
            //return View();
            List<SelectListItem> organizations = CreateOrganizationList();

            return View(new Employees() { OrganizationsList = organizations });

        }

        private List<SelectListItem> CreateOrganizationList()
        {
            return _employeesService.FindAllOrganization()
                            .Select(e => new SelectListItem()
                            {
                                Text = e.Name,
                                Value = e.ID.ToString(),
                            }).ToList();
        }


        [HttpPost]
        public IActionResult Create(Employees model)
        {
            if (ModelState.IsValid)
            {
                _employeesService.Add(model);
                return RedirectToAction("Index");
            }
            //return View();
            model.OrganizationsList = CreateOrganizationList();
            return View(model);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_employeesService.FindByID(id));
        }

        [HttpPost]
        public IActionResult Update(Employees model)
        {
            if(ModelState.IsValid)
            {
                _employeesService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet] 
        public IActionResult Delete(int id)
        {
            return View(_employeesService.FindByID(id));
        }

        [HttpPost]
        public IActionResult Delete(Employees model)
        {
            _employeesService.RemoveById(model.ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            return View(_employeesService.FindByID(id));
        }

        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult CreateApi()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CreateApi(Employees model)
        {
            if (ModelState.IsValid)
            {
                _employeesService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
