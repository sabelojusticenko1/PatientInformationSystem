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
    public class MedicalHistoryController : Controller
    {
        private readonly IMedicalHistoryService medicalHistoryService;
        private readonly IDiagnosisService diagnosisService;
        private readonly IStageService stageService;

        public MedicalHistoryController(IMedicalHistoryService medicalHistoryService, IDiagnosisService diagnosisService, IStageService stageService)
        {
            this.medicalHistoryService = medicalHistoryService;
            this.diagnosisService = diagnosisService;
            this.stageService = stageService;
        }
        public IActionResult Add()
        {
            var model = new MedicalHistory();
            model.DiagnosisNameList = diagnosisService.GetAll().Select(a => new SelectListItem{ Text = a.DiagnosisName, Value = a.Id.ToString() }).ToList();
            model.StageNameList = stageService.GetAll().Select(a => new SelectListItem { Text = a.StageName, Value = a.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add([Bind("IdMedicalHistory,IdPatient,ExaminationHistory,Examination,DiagnosisId,StageId")] MedicalHistory model )
        {
            model.IdPatient = Convert.ToInt32(TempData["IdPatient"]);
            model.DiagnosisNameList = diagnosisService.GetAll().Select(a => new SelectListItem { Text = a.DiagnosisName, Value = a.Id.ToString(), Selected = a.Id == model.DiagnosisId }).ToList();
            model.StageNameList = stageService.GetAll().Select(a => new SelectListItem { Text = a.StageName, Value = a.Id.ToString(), Selected = a.Id == model.StageId }).ToList();

            if (!ModelState.IsValid) 
            {
                return View(model);
            }
            var result = medicalHistoryService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                //return RedirectToAction(nameof(Add));
                return Redirect("/MedicalHistory/GetAll/" + model.IdPatient);
            }
            TempData["msg"] = "error";
            TempData["IdPatient"] = model.IdPatient;
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var model = medicalHistoryService.FindById(id);
            model.DiagnosisNameList = diagnosisService.GetAll().Select(a => new SelectListItem { Text = a.DiagnosisName, Value = a.Id.ToString(), Selected = a.Id == model.DiagnosisId }).ToList();
            model.StageNameList = stageService.GetAll().Select(a => new SelectListItem { Text = a.StageName, Value = a.Id.ToString(), Selected = a.Id == model.StageId }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(MedicalHistory model)
        {
            model.DiagnosisNameList = diagnosisService.GetAll().Select(a => new SelectListItem { Text = a.DiagnosisName, Value = a.Id.ToString(), Selected = a.Id == model.DiagnosisId }).ToList();
            model.StageNameList = stageService.GetAll().Select(a => new SelectListItem { Text = a.StageName, Value = a.Id.ToString(), Selected = a.Id == model.StageId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = medicalHistoryService.Update(model);
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
            var result = medicalHistoryService.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll(int? id)
        {

            var data = medicalHistoryService.GetAll().Where(m=>m.IdPatient==id).OrderBy(i=>i.IdMedicalHistory);
            TempData["IdPatient"] = id;
            return View(data);

        }
    }
}
