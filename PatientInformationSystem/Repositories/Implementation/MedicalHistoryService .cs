using Microsoft.AspNetCore.Mvc;
using PatientInformationSystem.Data;
using PatientInformationSystem.Models;
using PatientInformationSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Implementation
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly ApplicationDbContext context;

        public MedicalHistoryService(ApplicationDbContext context) {
            this.context = context;
        }

        public bool Add(MedicalHistory model)
        {
           
            try
            {
                context.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.MedicalHistorys.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public MedicalHistory FindById(int id)
        {
            return context.MedicalHistorys.Find(id);
        }

        public IEnumerable<MedicalHistory> GetAll()
        {
            var data = (from medicalHistory in context.MedicalHistorys
                        join diagnosis in context.Diagnosiss
                        on medicalHistory.DiagnosisId equals diagnosis.Id
                        join stage in context.Stages
                        on medicalHistory.StageId equals stage.Id
                        select new MedicalHistory
                        {
                            IdMedicalHistory = medicalHistory.IdMedicalHistory,
                            DiagnosisId = medicalHistory.DiagnosisId,
                            StageId = medicalHistory.StageId,
                            ExaminationHistory = medicalHistory.ExaminationHistory,
                            Examination = medicalHistory.Examination,
                            DiagnosisName = diagnosis.DiagnosisName,
                            StageName =stage.StageName,
                            IdPatientNoNavigation = medicalHistory.IdPatientNoNavigation,
                            IdPatient = medicalHistory.IdPatient
                        }).ToList();
            return data;
        }
    public bool Update(MedicalHistory model)
        {
            try
            {
                context.MedicalHistorys.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
