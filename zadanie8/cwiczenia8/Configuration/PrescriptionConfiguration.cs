using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cwiczenia8.Configuration
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey( e => e.IdPrescription ).HasName( "Prescription_pk" );

            builder.Property( e => e.Date ).IsRequired();
            builder.Property( e => e.DueDate );

            builder.ToTable( "Prescription" );

            builder.HasMany( e => e.PrescriptionMedicaments ).WithOne( x => x.IPrescriptionNavigation )
                .HasForeignKey( k => k.IdPrescription );

            var prescriptions = new List<Prescription>
            {
                new Prescription
                {
                    IdPrescription = 1,
                    IdDoctor = 1,
                    IdPatient = 1,
                    Date = DateTime.Now.AddMonths(3),
                    DueDate = DateTime.Now.AddMonths(-3),
                },
                
                new Prescription
                {
                    IdPrescription = 2,
                    IdDoctor = 2,
                    IdPatient = 2,
                    Date = DateTime.Now.AddMonths(6),
                    DueDate = DateTime.Now.AddMonths(-2),
                }
            };

            builder.HasData(prescriptions);
        }
    }
}
