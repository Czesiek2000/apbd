using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cwiczenia8.Configuration
{
    public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable( "Prescription_medicament" );

            builder.Property(e => e.IdMedicament).UseIdentityColumn();

            builder.Property(e => e.Dose).IsRequired();

            builder.Property(e => e.Details).HasMaxLength(100).IsRequired();

            builder.HasKey( e => new { e.IdMedicament, e.IdPrescription } ).HasName( "Prescription_medicament_pk" );

            builder.HasOne(e => e.IMedicamentNavigation)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicament_prescriptionMedicament");

            builder.HasOne(e => e.IMedicamentNavigation)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescription_prescriptionMedicament");

            var prescriptionsMedicaments = new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 100, Details = "Prescription for 1 medicament"},
                new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 1000, Details = "Prescription details"},
            };

            builder.HasData(prescriptionsMedicaments);
        }
    }
}
