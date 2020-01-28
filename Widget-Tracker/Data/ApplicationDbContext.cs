using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Widget_Tracker.Models;

namespace Widget_Tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Lot> Lots { get; set; }

        public DbSet<LotProcess> LotProcesses { get; set; }

        public DbSet<Process> Processes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",                
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Process>().HasMany(process => process.LotProcesses)
                       .WithOne(lotprocess => lotprocess.Process)
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lot>().HasMany(lot => lot.LotProcesses)
                       .WithOne(lotprocess => lotprocess.Lot)
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Process>()
               .Property(D => D.TimeStamp)
               .HasDefaultValueSql("GETDATE()");
        }



    }
}