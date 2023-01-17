using PatientInformationSystem.Data;
using PatientInformationSystem.Models;
using PatientInformationSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext context;

        public PatientService(ApplicationDbContext context) {
            this.context = context;
        }

        public bool Add(Patient model)
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
                context.Patients.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Patient FindById(int id)
        {
            return context.Patients.Find(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            var data = (from patient in context.Patients
                        join gender in context.Genders
                        on patient.GenderId equals gender.Id
                        join hospital in context.Hospitals
                        on patient.HospitalId equals hospital.Id
                        select new Patient
                        {
                            IdPatient = patient.IdPatient,
                            GenderId = patient.GenderId,
                            HospitalId = patient.HospitalId,
                            FirstName = patient.FirstName,
                            Surname = patient.Surname,
                            Age = patient.Age,
                            Address = patient.Address,
                            IDNumber = patient.IDNumber,
                            GenderType = gender.GenderType,
                            HospitalName =hospital.HospitalName
                        }).ToList();
            return data;
        }

        public bool Update(Patient model)
        {
            try
            {
                context.Patients.Update(model);
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
