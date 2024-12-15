using Garden.Management.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garden.Management.Infrastructure
{
    public class GardenDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Keeper> Keepers { get; set; }
        public GardenDbContext(DbContextOptions<GardenDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Plant>()
               .HasMany(s => s.Keepers)
               .WithMany(c => c.Plants)
               .UsingEntity(j => j.ToTable("KeeperPlantChart"));

            base.OnModelCreating(modelBuilder);
            // Removed this code - As data tried to get added each call.
            /*
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GardenDbContext).Assembly);
            
            // Seed junction table (this part needs to be done with the EF Core's Fluent API)
            // Seed junction table population has to be done at here in OnModelCreating, rather than
            // configuring through IEntityTypeConfiguration as the junction entity is not exists, but table exists in db
            modelBuilder.Entity<Plant>()
                .HasMany(s => s.Keepers)
                .WithMany(c => c.Plants)
                .UsingEntity(j => j
                    .ToTable("KeeperPlantChart")
                    .HasData(
                        new { KeepersId = Guid.Parse("056fcd24-ed30-4d42-8a55-61710289b921"), PlantsId = Guid.Parse("3a853de2-ceee-47fd-a653-9c2611b56eac") },
                        new { KeepersId = Guid.Parse("056fcd24-ed30-4d42-8a55-61710289b921"), PlantsId = Guid.Parse("3a853de2-ceee-47fd-a653-9c2611b56ead") }
                    ));
            */

            // Removed below code from Program.cs
            // This needed the database should be pre-existed . Commented below code as it gets invoked each call
            /*using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GardenDbContext>();
            db.Database.Migrate();
            */



        }
    }
}