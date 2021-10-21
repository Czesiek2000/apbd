using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium1.Configuration
{
    public class FiretruckConfiguration : IEntityTypeConfiguration<Firetruck>
    {
        public void Configure ( EntityTypeBuilder<Firetruck> builder )
        {
            builder.ToTable( "Firetruck" );

            builder.HasKey( e => e.IdFireTruck ).HasName( "firetruck_pk" );

            builder.Property( e => e.IdFireTruck ).UseIdentityColumn();

            builder.Property( e => e.OperationalNumber ).HasMaxLength( 10 ).IsRequired();

            builder.Property( e => e.SpecialEquipment ).IsRequired();

            //        var firetrucks = new List<Firetruck>
            //{
            //    new Firetruck
            //    {
            //        IdFiretruck = 1,
            //        OperationalNumber = "123",
            //        SpecialEquipment = 1,
            //        FiretruckActions = new List<FiretruckAction>
            //        {
            //            new FiretruckAction
            //            {
            //                IdAction = 1,
            //                IdFiretruck = 1,
            //                IdFiretruckAction = 1,
            //                AssignmentDate = DateTime.Now,

            //            }
            //        }
            //    }
            //};

            //        builder.HasData( firetrucks );
        }
    }
}
