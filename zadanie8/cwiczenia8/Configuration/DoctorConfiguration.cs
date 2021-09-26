using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cwiczenia8.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable( "Doctor" );

            builder.HasKey( e => e.IdDoctor ).HasName( "Doctor_pk" );

            builder.Property( e => e.IdDoctor ).UseIdentityColumn();

            builder.Property( e => e.FirstName ).HasMaxLength( 100 ).IsRequired();

            builder.Property( e => e.LastName ).HasMaxLength( 100 ).IsRequired();

            builder.Property( e => e.Email ).HasMaxLength( 100 );

            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Jan", 
                    LastName = "Kowalski", Email = "jan@kowalski.com",
                    Prescriptions = new List<Prescription>()
                    {
                        new Prescription
                        {
                            IdPrescription = 1,
                            Date = DateTime.Now,
                            DueDate = DateTime.Now.AddDays(3),
                            IdDoctor = 1,
                            IdPatient = 1,
                        }
                    }
                },
                
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Anna", 
                    LastName = "Nowak", Email = "anna.nowak@gmail.com",
                    Prescriptions = new List<Prescription>()
                    {
                        new Prescription
                        {
                            IdPrescription = 2,
                            Date = DateTime.Now.AddDays(1),
                            DueDate = DateTime.Now.AddDays(2),
                            IdDoctor = 2,
                            IdPatient = 2,
                        }
                    }
                }
            };

            builder.HasData(doctors);
        }
    }
}
