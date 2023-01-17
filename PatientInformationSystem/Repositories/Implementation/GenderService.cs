using PatientInformationSystem.Data;
using PatientInformationSystem.Models;
using PatientInformationSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Implementation
{
    public class GenderService : IGenderService
    {
        private readonly ApplicationDbContext context;

        public GenderService(ApplicationDbContext context) {
            this.context = context;
        }

        public bool Add(Gender model)
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
                context.Genders.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Gender FindById(int id)
        {
            return context.Genders.Find(id);
        }

        public IEnumerable<Gender> GetAll()
        {
            return context.Genders.ToList();
        }

        public bool Update(Gender model)
        {
            try
            {
                context.Genders.Update(model);
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
