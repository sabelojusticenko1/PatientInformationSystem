using Microsoft.AspNetCore.Mvc;
using PatientInformationSystem.Models;
using PatientInformationSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderService service;

        public GenderController(IGenderService service)
        {
            this.service = service;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Gender model )
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }
            var result = service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "error";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Gender model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(GetAll));
            }
            TempData["msg"] = "error";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return View(data);
        }
    }
}
