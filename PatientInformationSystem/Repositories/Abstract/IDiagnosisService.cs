using PatientInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Abstract
{
    public interface IDiagnosisService
    {
        bool Add(Diagnosis model);
        bool Update(Diagnosis model);
        bool Delete(int id);
        Diagnosis FindById(int id);
        IEnumerable<Diagnosis> GetAll();
    }
}
