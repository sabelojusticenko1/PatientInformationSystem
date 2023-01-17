using PatientInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.ViewModel
{
    public class PatientViewModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public string IDNumber { get; set; }
        public string Address { get; set; }
        public int GenderId { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
        public virtual ICollection<MedicalHistory> MedicalHistory { get; set; }
    }
}
