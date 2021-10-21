using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium1.Configuration
{
    public class FirefighterActionConfiguration : IEntityTypeConfiguration<FirefighterAction>
    {
        public void Configure ( EntityTypeBuilder<FirefighterAction> builder )
        {
            builder.ToTable( "Firefighter_action" );

            builder.HasKey( e => new { e.IdAction, e.IdFirefighter } ).HasName( "Firefighteraction_pk" );

            //builder.HasOne( x => x.IActionNavigation )
            //    .WithMany( p => p.FirefighterActions )
            //    .OnDelete( DeleteBehavior.ClientSetNull )
            //    .HasConstraintName( "Firefighter_firefighteraction" );

            //var firefighterActions = new List<FirefighterAction>
            //{
            //    new FirefighterAction
            //    {
            //        IdAction = 1,
            //        IdFirefighter = 1
            //    }
            //};

            //builder.HasData( firefighterActions );
        }
    }
}
