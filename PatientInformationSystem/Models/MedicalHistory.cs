using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Models
{
    public class MedicalHistory
    {
        [Key]
        public int IdMedicalHistory { get; set; }

        [Column("IdPatient")]
        public int? IdPatient { get; set; }

        [Required]
        [Display(Name = "Examination History")]
        public string ExaminationHistory { get; set; }

        [Required]
        [Display(Name = "Examination")]
        public string Examination { get; set; }

        public int DiagnosisId { get; set; }
        public int StageId { get; set; }

        [NotMapped]
        public string? DiagnosisName { get; set; }
        [NotMapped]
        public string? StageName { get; set; }
        [NotMapped]
        public List<SelectListItem>? DiagnosisNameList { get; set; }
        [NotMapped]
        public List<SelectListItem>? StageNameList { get; set; }

        [ForeignKey(nameof(IdPatient))]
        [InverseProperty(nameof(Patient.MedicalHistory))]
        public virtual Patient IdPatientNoNavigation { get; set; }

        public virtual ICollection<Note> Note { get; set; }

    }
}
