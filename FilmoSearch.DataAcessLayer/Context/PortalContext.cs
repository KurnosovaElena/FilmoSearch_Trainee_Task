using FilmoSearch.DataAcessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmoSearch.DataAcessLayer.Context
{
    public class PortalContext : DbContext
    {
        public PortalContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DataGenerator.Init();

            modelBuilder.Entity<Film>().HasData(DataGenerator.Films);
            modelBuilder.Entity<Review>().HasData(DataGenerator.Reviews);
            modelBuilder.Entity<Actor>().HasData(DataGenerator.Actors);
        }
    }
}