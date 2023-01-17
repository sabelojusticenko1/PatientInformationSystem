using PatientInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Abstract
{
    public interface INoteService
    {
        bool Add(Note model);
        bool Update(Note model);
        bool Delete(int id);
        Note FindById(int id);
        IEnumerable<Note> GetAll();
    }
}
