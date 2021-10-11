using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieApp.Shared.Models;

namespace MovieApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Genre>(opt =>
            {
                opt.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });

            builder.Entity<Person>(opt =>
            {
                opt.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });

            builder.Entity<MoviesActors>(opt =>
            {
                opt.HasKey(p => new { p.MovieId, p.PersonId });
                opt.HasOne(p => p.Person)
                   .WithMany(p => p.MoviesActors)
                   .HasForeignKey(p => p.PersonId);
                opt.HasOne(p => p.Movie)
                   .WithMany(p => p.MoviesActors)
                   .HasForeignKey(p => p.MovieId);
            });

            builder.Entity<MoviesGenres>(opt =>
            {
                opt.HasKey(p => new { p.MovieId, p.GenreId });
                opt.HasOne(p => p.Genre)
                   .WithMany(p => p.MoviesGenres)
                   .HasForeignKey(p => p.GenreId);
                opt.HasOne(p => p.Movie)
                   .WithMany(p => p.MoviesGenres)
                   .HasForeignKey(p => p.MovieId);
            });

            base.OnModelCreating(builder);
        }
    }
}
