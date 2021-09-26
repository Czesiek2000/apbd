using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cwiczenia8.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable( "Patient" );
            builder.HasKey( e => e.IdPatient );
            builder.Property( e => e.FirstName ).IsRequired();
            builder.Property( e => e.LastName ).IsRequired();
            builder.Property( e => e.Birthdate ).IsRequired();

            builder.Property( e => e.IdPatient ).UseIdentityColumn();

            builder.HasMany( e => e.Prescriptions ).WithOne( e => e.IPatientNavigation )
                .HasForeignKey( e => e.IdPatient ).IsRequired();

            var patients = new List<Patient>
            {
                new Patient
                {
                    IdPatient = 1,
                    Birthdate = DateTime.Now,
                    FirstName = "Marian",
                    LastName = "Zielony",
                },
                
                new Patient
                {
                    IdPatient = 2,
                    Birthdate = DateTime.Now.AddDays(5),
                    FirstName = "Janina",
                    LastName = "Pietruszka",
                }
            };

            builder.HasData(patients);
        }
    }
}
