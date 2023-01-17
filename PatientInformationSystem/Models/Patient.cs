using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Models
{
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Age")]
        public string Age { get; set; }

        [Required]
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        public int ? GenderId { get; set; }

        [Required]
        public int ? HospitalId { get; set; }

        [NotMapped]
        public string ? GenderType { get; set; }
        [NotMapped]
        public string ? HospitalName { get; set; }
        [NotMapped]
        public List<SelectListItem> ? GenderTypeList { get; set; }
        [NotMapped]
        public List<SelectListItem> ? HospitalNameList { get; set; }

        public virtual ICollection<MedicalHistory> MedicalHistory { get; set; }
    }
}
