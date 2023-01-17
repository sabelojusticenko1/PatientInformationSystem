using PatientInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Abstract
{
    public interface IMedicalHistoryService
    {
        bool Add(MedicalHistory model);
        bool Update(MedicalHistory model);
        bool Delete(int id);
        MedicalHistory FindById(int id);
        IEnumerable<MedicalHistory> GetAll();
    }
}
