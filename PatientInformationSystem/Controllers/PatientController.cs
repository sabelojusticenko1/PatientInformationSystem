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
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;
        private readonly IGenderService genderService;
        private readonly IHospitalService hospitalService;

        public PatientController(IPatientService patientService,IGenderService genderService, IHospitalService hospitalService)
        {
            this.patientService = patientService;
            this.genderService = genderService;
            this.hospitalService = hospitalService;
        }
        public IActionResult Add()
        {
            var model = new Patient();
            model.GenderTypeList = genderService.GetAll().Select(a => new SelectListItem{ Text = a.GenderType, Value = a.Id.ToString() }).ToList();
            model.HospitalNameList = hospitalService.GetAll().Select(a => new SelectListItem { Text = a.HospitalName, Value = a.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Patient model )
        {
            model.GenderTypeList = genderService.GetAll().Select(a => new SelectListItem { Text = a.GenderType, Value = a.Id.ToString(), Selected = a.Id == model.GenderId }).ToList();
            model.HospitalNameList = hospitalService.GetAll().Select(a => new SelectListItem { Text = a.HospitalName, Value = a.Id.ToString(), Selected = a.Id == model.HospitalId }).ToList();

            if (!ModelState.IsValid) 
            {
                return View(model);
            }
            var result = patientService.Add(model);
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
            var model = patientService.FindById(id);
            model.GenderTypeList = genderService.GetAll().Select(a => new SelectListItem { Text = a.GenderType, Value = a.Id.ToString(), Selected = a.Id == model.GenderId }).ToList();
            model.HospitalNameList = hospitalService.GetAll().Select(a => new SelectListItem { Text = a.HospitalName, Value = a.Id.ToString(), Selected = a.Id == model.HospitalId }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Patient model)
        {
            model.GenderTypeList = genderService.GetAll().Select(a => new SelectListItem { Text = a.GenderType, Value = a.Id.ToString(), Selected = a.Id == model.GenderId }).ToList();
            model.HospitalNameList = hospitalService.GetAll().Select(a => new SelectListItem { Text = a.HospitalName, Value = a.Id.ToString(), Selected = a.Id == model.HospitalId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = patientService.Update(model);
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
            var result = patientService.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll()
        {
            var data = patientService.GetAll();
            return View(data);
        }
    }
}
