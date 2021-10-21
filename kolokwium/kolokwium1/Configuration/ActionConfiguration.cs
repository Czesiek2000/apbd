using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kolokwium1.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = kolokwium1.Models.Action;


namespace kolokwium1.Configuration
{
    public class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure ( EntityTypeBuilder<Action> builder )
        {
            builder.ToTable( "Action" );

            builder.HasKey( e => e.IdAction ).HasName( "Action_pk" );

            builder.Property( e => e.IdAction ).UseIdentityColumn();

            builder.Property( e => e.StartTime ).IsRequired();

            builder.Property( e => e.EndTime ).IsRequired();

            builder.Property( e => e.NeedSpecialEquipment ).IsRequired();


            //        var actions = new List<Action>
            //        {
            //            new Action()
            //            {
            //                IdAction = 1,
            //                StartTime = DateTime.Now,
            //                EndTime = DateTime.Now.AddDays(1),
            //FirefighterActions = new List<FirefighterAction>()
            //{
            //    new FirefighterAction()
            //    {
            //        IdAction = 1,
            //        IdFirefighter = 1,
            //    },
            //    new FirefighterAction()
            //    {
            //        IdAction = 2,
            //        IdFirefighter = 2,
            //    }
            //},
            //FiretruckActions = new List<FiretruckAction>()
            //{
            //    new FiretruckAction()
            //    {
            //        IdAction = 1,
            //        IdFiretruck = 1,
            //        IdFiretruckAction = 1,
            //        AssignmentDate = DateTime.Now
            //    },
            //    new FiretruckAction()
            //    {
            //        IdAction = 2,
            //        IdFiretruck = 2,
            //        IdFiretruckAction = 2,
            //        AssignmentDate = DateTime.Now
            //    }
            //},
            //                NeedSpecialEquipment = 1
            //            }
            //        };

            //        builder.HasData(actions);
        }
    }
}
