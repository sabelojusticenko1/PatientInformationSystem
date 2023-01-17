using PatientInformationSystem.Data;
using PatientInformationSystem.Models;
using PatientInformationSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Implementation
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly ApplicationDbContext context;

        public DiagnosisService(ApplicationDbContext context) {
            this.context = context;
        }

        public bool Add(Diagnosis model)
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
                context.Diagnosiss.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Diagnosis FindById(int id)
        {
            return context.Diagnosiss.Find(id);
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            return context.Diagnosiss.ToList();
        }

        public bool Update(Diagnosis model)
        {
            try
            {
                context.Diagnosiss.Update(model);
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
