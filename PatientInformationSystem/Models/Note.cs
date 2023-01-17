using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Column("IdMedicalHistory")]
        public int? IdMedicalHistory { get; set; }

        [Required]
        public string Notetype { get; set; }

        [ForeignKey(nameof(IdMedicalHistory))]
        [InverseProperty(nameof(MedicalHistory.Note))]
        public virtual MedicalHistory IdMedicalHistoryNoNavigation { get; set; }
    }
}
