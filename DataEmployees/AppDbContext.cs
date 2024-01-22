using DataEmployees.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace DataEmployees
{
    public class AppDbContext : IdentityDbContext<IdentityUser> //DbContext
    {
        public DbSet<EmployeesEntity> Employees { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }

        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "employees.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"data source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //tworzenie użytkownika


            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();

            string USER_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();


            var admin = new IdentityUser()
            {
                Id = ADMIN_ID,
                UserName = "Test",
                NormalizedUserName = "TEST",
                Email = "test@wsei.edu.pl",
                NormalizedEmail = "TEST@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            //
            var user = new IdentityUser()
            {
                Id = USER_ID,
                UserName = "User",
                NormalizedUserName = "USER",
                Email = "user@wsei.edu.pl",
                NormalizedEmail = "USER@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "1234Ab!");

            //
            PasswordHasher<IdentityUser> passwordHasher2 = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher2.HashPassword(user, "Start123!");



            //tworzenie roli
            var adminRole = new IdentityRole
            {
                Name = "ADMIN",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            };



            var userRole = new IdentityRole
            {
                Name = "USER",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            };



            modelBuilder.Entity<IdentityUser>().HasData(user, admin);
            modelBuilder.Entity<IdentityRole>().HasData(adminRole, userRole);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = ADMIN_ROLE_ID, UserId = ADMIN_ID },
                new IdentityUserRole<string> { RoleId = USER_ROLE_ID, UserId = USER_ID }

            );



            modelBuilder.Entity<EmployeesEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OrganizationID);

            modelBuilder.Entity<OrganizationEntity>()
                .HasData(
                    new OrganizationEntity()
                    {
                        ID = 101,
                        Name = "WSEI",
                        Description = "Uczelnia"
                    },
                    new OrganizationEntity()
                    {
                        ID = 102,
                        Name = "Koło studenckie WSEI",
                        Description = "Koło studenckie"
                    }
                 );

            modelBuilder.Entity<OrganizationEntity>()
           .OwnsOne(o => o.Address)
           .HasData(
           new
           {
               OrganizationEntityID = 101,
               City = "Kraków",
               Street = "Św. Filipa 17",
               PostalCode = "31-150"
           },
           new
           {
               OrganizationEntityID = 102,
               City = "Kraków",
               Street = "Św. Filipa 17, pok. 12",
               PostalCode = "31-150"
           }
           );


        }
    }
}   