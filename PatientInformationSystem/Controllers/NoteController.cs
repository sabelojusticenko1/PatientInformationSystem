using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatientInformationSystem.Models;
using PatientInformationSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService service;

        public NoteController(INoteService service)
        {
            this.service = service;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind("Id,IdMedicalHistory,Notetype")] Note model )
        {
            model.IdMedicalHistory = Convert.ToInt32(TempData["IdMedicalHistory"]);
            if (!ModelState.IsValid) 
            {
                return View(model);
            }
            var result = service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                //return RedirectToAction(nameof(Add));
                return Redirect("/Note/GetAll/" + model.IdMedicalHistory);
            }
            TempData["msg"] = "error";
            TempData["IdMedicalHistory"] = model.IdMedicalHistory;
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,IdMedicalHistory,Notetype")] Note model)
        {
            model.IdMedicalHistory = Convert.ToInt32(TempData["IdMedicalHistory"]);
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                //return RedirectToAction(nameof(GetAll));
                return Redirect("/Note/GetAll/" + model.IdMedicalHistory);
            }
            TempData["msg"] = "error";
            TempData["IdMedicalHistory"] = model.IdMedicalHistory;
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll(int? id)
        {
            var data = service.GetAll().Where(m => m.IdMedicalHistory == id).OrderBy(i => i.Id);
            TempData["IdMedicalHistory"] = id;
            return View(data);
        }
    }
}
