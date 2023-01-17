using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatientInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientInformationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalHistory> MedicalHistorys { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Diagnosis> Diagnosiss { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Note> Notes { get; set; }



    }
}
