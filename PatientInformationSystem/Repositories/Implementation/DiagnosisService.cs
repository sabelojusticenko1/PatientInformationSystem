using PatientInformationSystem.Data;
using PatientInformationSystem.Models;
using PatientInformationSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Implementation
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext context;

        public NoteService(ApplicationDbContext context) {
            this.context = context;
        }

        public bool Add(Note model)
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
                context.Notes.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Note FindById(int id)
        {
            return context.Notes.Find(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return context.Notes.ToList();
        }

        public bool Update(Note model)
        {
            try
            {
                context.Notes.Update(model);
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
