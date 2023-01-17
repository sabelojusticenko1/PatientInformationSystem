using PatientInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Abstract
{
    public interface IStageService
    {
        bool Add(Stage model);
        bool Update(Stage model);
        bool Delete(int id);
        Stage FindById(int id);
        IEnumerable<Stage> GetAll();
    }
}
