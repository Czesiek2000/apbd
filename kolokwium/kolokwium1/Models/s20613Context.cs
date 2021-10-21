using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium1.Configuration;
using Microsoft.EntityFrameworkCore;

namespace kolokwium1.Models
{
    public class s20613Context : DbContext
    {
        public s20613Context(){}

        public s20613Context(DbContextOptions<s20613Context> options) : base(options) {}

        public virtual DbSet<Action> Actions { get; set; }

        public virtual DbSet<Firefighter> Firefighters { get; set; }

        public virtual DbSet<FirefighterAction> FirefighterActions { get; set; }

        public virtual DbSet<FiretruckAction> FiretruckActions { get; set; }

        public virtual DbSet<Firetruck> Firetrucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActionConfiguration());
            modelBuilder.ApplyConfiguration(new FirefighterActionConfiguration());
            modelBuilder.ApplyConfiguration(new FirefighterConfiguration());
            modelBuilder.ApplyConfiguration(new FiretruckActionConfiguration());
            modelBuilder.ApplyConfiguration(new FiretruckConfiguration());
        }
    }
}
