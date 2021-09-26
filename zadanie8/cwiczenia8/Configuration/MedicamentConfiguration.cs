using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cwiczenia8.Configuration
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.ToTable( "Medicament" );

            builder.HasKey( e => e.IdMedicament );

            builder.Property( e => e.IdMedicament ).UseIdentityColumn();

            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();

            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();

            builder.Property(e => e.Type).HasMaxLength(100);

            builder.HasMany( e => e.PrescriptionMedicaments ).WithOne( e => e.IMedicamentNavigation )
                .HasForeignKey( e => e.IdMedicament ).IsRequired();


            var medicaments = new List<Medicament>
            {
                new Medicament{IdMedicament = 1, Name = "Apap", Description = "Headache medicament", Type = "Strong"},
                new Medicament{IdMedicament = 2, Name = "Ibum", Description = "Better headache medicament", Type = "Strong"},
            };

            builder.HasData(medicaments);
        }
    }
}
