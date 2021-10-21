using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium1.Configuration
{
    public class FirefighterConfiguration : IEntityTypeConfiguration<Firefighter>
    {
        public void Configure ( EntityTypeBuilder<Firefighter> builder )
        {
            builder.ToTable( "Firefighter" );

            builder.HasKey( e => e.IdFirefighter ).HasName( "firefighter_pk" );

            builder.Property( e => e.IdFirefighter ).UseIdentityColumn();

            builder.Property( e => e.FirstName ).HasMaxLength( 30 ).IsRequired();

            builder.Property( e => e.LastName ).HasMaxLength( 50 ).IsRequired();

            //var firefighters = new List<Firefighter>()
            //{
            //    new Firefighter
            //    {
            //        IdFirefighter = 1,
            //        FirstName = "Jan",
            //        LastName = "Kowalski",
            //        FirefighterActions = new List<FirefighterAction>()
            //        {
            //            new FirefighterAction
            //            {
            //                IdAction = 1,
            //                IdFirefighter = 1,
            //            }
            //        }
            //    }
            //};

            //builder.HasData(firefighters);
        }
    }
}
