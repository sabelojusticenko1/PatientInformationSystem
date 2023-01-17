﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientInformationSystem.Models
{
    public class Stage
    {
        public int Id { get; set; }
        [Required]
        public string StageName { get; set; }
    }
}
