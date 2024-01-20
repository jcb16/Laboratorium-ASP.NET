using Laboratorium_3___App___Employees.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium_3___App.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmployeesController : Controller
    {

        private readonly IDateTimeProvider _timeProvider;
        private readonly IEmployeesService _employeesService;

        //check
        //private readonly IRecentlyDeletedEmployeesService _recentlyDeletedEmployeesService;


        //
        //public IActionResult RecentlyDeletedEmployees()
        //{
        //    var recentlyDeletedEmployees = _recentlyDeletedEmployeesService.GetRecentlyDeletedEmployees();
        //    return View("RecentlyDeleted", recentlyDeletedEmployees);
        //}
        //

        public EmployeesController(IEmployeesService employeesService, IDateTimeProvider timeProvider) /*IRecentlyDeletedEmployeesService recentlyDeletedEmployeesService)*/
        {
            _employeesService = employeesService;
            _timeProvider = timeProvider;
            //check
            //_recentlyDeletedEmployeesService = recentlyDeletedEmployeesService;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_employeesService.FindAll());
        }

        public IActionResult PagedIndex(int page = 1, int size = 6, string department = "")
        {
            if (size < 2)
            {
                return BadRequest();
            }
            return View(_employeesService.FindPage(page, size));

            //var filteredData = _employeesService.GetEmployeesByDepartment(department);
            // Dodaj kod paginacji, jeśli jest potrzebny

            //return PartialView("_EmployeeTablePartial", filteredData);


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

        [HttpGet]
        public IActionResult Create()
        {
            //return View();
            List<SelectListItem> organizations = CreateOrganizationList();

            //return View(new Employees() { OrganizationsList = organizations });
            var newEmployee = new Employees
            {
                OrganizationsList = organizations,
                Created = _timeProvider.GetCurrentData() // Ustawianie daty utworzenia
            };

            return View(newEmployee);

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
            //return View(_employeesService.FindByID(id));
            var find = _employeesService.FindByID(id);
            if (find == null)
            {
                return NotFound();
            }
            return View(find);
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


        //[HttpPost]
        //public IActionResult RecentlyDeleted(Employees model)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    _employeesService.Add(model);
        //    //    return RedirectToAction("Index");
        //    //}
        //    return View();
        //}


    }
}
