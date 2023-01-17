using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Models
{
    public class Service
    {
        [Key]
        public int IdService { get; set; }

        [Column("IdIdMedicalHistory")]
        public int? IdIdMedicalHistory { get; set; }

    }
}
