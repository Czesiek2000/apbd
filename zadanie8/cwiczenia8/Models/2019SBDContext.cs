using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia8.Configuration;

namespace cwiczenia8.Models
{
    public class _2019SBDContext : DbContext
    {
        public _2019SBDContext() { }

        public _2019SBDContext(DbContextOptions<_2019SBDContext> options) : base( options )
        {

        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());

            modelBuilder.ApplyConfiguration(new PatientConfiguration());

            modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());

            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());

            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
