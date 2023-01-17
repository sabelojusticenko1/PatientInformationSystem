using PatientInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Abstract
{
    public interface IPatientService
    {
        bool Add(Patient model);
        bool Update(Patient model);
        bool Delete(int id);
        Patient FindById(int id);
        IEnumerable<Patient> GetAll();
    }
}
