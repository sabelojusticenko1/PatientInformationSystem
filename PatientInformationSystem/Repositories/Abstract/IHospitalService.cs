using PatientInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Repositories.Abstract
{
    public interface IHospitalService
    {
        bool Add(Hospital model);
        bool Update(Hospital model);
        bool Delete(int id);
        Hospital FindById(int id);
        IEnumerable<Hospital> GetAll();
    }
}
