using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium_3___App.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        ////lista kontaktów
        //static Dictionary<int,Contact> _contacts = new Dictionary<int,Contact>();
        //static int id = 1;
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
            //_contacts
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> organizations = CreateOrganizationList();

            return View(new Contact() { OrganizationsList = organizations });

        }

        private List<SelectListItem> CreateOrganizationList()
        {
            return _contactService.FindAllOrganization()
                            .Select(e => new SelectListItem()
                            {
                                Text = e.Name,
                                Value = e.ID.ToString(),
                            }).ToList();
        }

        [HttpPost]
        public IActionResult Create(Contact model) { 
            if(ModelState.IsValid)
            {
                // dodaj model do bazy lub kolekcji 
                //model.ID = id++;
                //_contacts.Add(model.ID, model);
                //return RedirectToAction("Index");
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            model.OrganizationsList = CreateOrganizationList();
            return View(model);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if(ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet] 
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.RemoveById(model.ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }


        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }

    }
}
