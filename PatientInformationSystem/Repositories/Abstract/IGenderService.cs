using PatientInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Abstract
{
    public interface IGenderService
    {
        bool Add(Gender model);
        bool Update(Gender model);
        bool Delete(int id);
        Gender FindById(int id);
        IEnumerable<Gender> GetAll();
    }
}
