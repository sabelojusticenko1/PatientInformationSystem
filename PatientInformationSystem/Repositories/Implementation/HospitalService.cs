using PatientInformationSystem.Data;
using PatientInformationSystem.Models;
using PatientInformationSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Implementation
{
    public class HospitalService : IHospitalService
    {
        private readonly ApplicationDbContext context;

        public HospitalService(ApplicationDbContext context) {
            this.context = context;
        }

        public bool Add(Hospital model)
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
                context.Hospitals.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Hospital FindById(int id)
        {
            return context.Hospitals.Find(id);
        }

        public IEnumerable<Hospital> GetAll()
        {
            return context.Hospitals.ToList();
        }

        public bool Update(Hospital model)
        {
            try
            {
                context.Hospitals.Update(model);
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
