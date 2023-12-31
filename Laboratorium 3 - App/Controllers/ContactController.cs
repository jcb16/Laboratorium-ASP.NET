﻿using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium_3___App.Controllers
{
    //[Authorize(Roles = "admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        //private readonly IDateTimeProvider _dateTimeProvider;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
            //_dateTimeProvider = CurrentDateTimeProvider;
        }


        ////lista kontaktów
        //static Dictionary<int,Contact> _contacts = new Dictionary<int,Contact>();
        //static int id = 1;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
            //_contacts
        }


        public IActionResult PagedIndex(int page = 1, int size = 5)
        {
            if(size < 2)
            {
                return BadRequest();
            }
            return View(_contactService.FindPage(page,size));
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
            var find = _contactService.FindById(id);
            if(find == null)
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
        public IActionResult CreateApi(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
