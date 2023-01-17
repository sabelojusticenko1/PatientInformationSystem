using PatientInformationSystem.Data;
using PatientInformationSystem.Models;
using PatientInformationSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Implementation
{
    public class StageService : IStageService
    {
        private readonly ApplicationDbContext context;

        public StageService(ApplicationDbContext context) {
            this.context = context;
        }

        public bool Add(Stage model)
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
                context.Stages.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Stage FindById(int id)
        {
            return context.Stages.Find(id);
        }

        public IEnumerable<Stage> GetAll()
        {
            return context.Stages.ToList();
        }

        public bool Update(Stage model)
        {
            try
            {
                context.Stages.Update(model);
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
