using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarApp.Models
{
    
    public class AppIdentityDbContext: IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarService> CarServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(a => a.CarService)
                .WithOne(b => b.Car)
                .HasForeignKey<CarService>(b => b.Id);
        }
    }
}
