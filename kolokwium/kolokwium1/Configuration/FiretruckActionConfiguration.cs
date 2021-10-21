using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium1.Configuration
{
    public class FiretruckActionConfiguration : IEntityTypeConfiguration<FiretruckAction>
    {
        public void Configure ( EntityTypeBuilder<FiretruckAction> builder )
        {
            builder.ToTable( "Firetruck_action" );

            builder.HasKey( e => new { e.IdAction, e.IdFireTruck } ).HasName( "Firetruck_action_pk" );

            //builder.HasOne( e => e.IdFiretruckNavigation )
            //    .WithMany( e => e.FiretruckActions )
            //    .OnDelete( DeleteBehavior.ClientSetNull )
            //    .HasConstraintName( "Firetruck_firetruckaction" );

            //builder.HasOne( e => e.IFiretruckNavigation )
            //    .WithMany( e => e.FiretruckActions )
            //    .OnDelete( DeleteBehavior.ClientSetNull )
            //    .HasConstraintName( "Firetruck_firetruckaction" );

            //var firetruckActions = new List<FiretruckAction>
            //{
            //    new FiretruckAction
            //    {
            //        IdAction = 1,
            //        IdFiretruck = 1,
            //        IdFiretruckAction = 1,
            //    }
            //};

            //builder.HasData( firetruckActions );
        }
    }
}
