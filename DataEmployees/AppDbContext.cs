﻿using DataEmployees.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Test",
                NormalizedUserName = "TEST",
                Email = "test@wsei.edu.pl",
                NormalizedEmail = "TEST@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "1234Ab!");

            modelBuilder.Entity<IdentityUser>()
                .HasData(user);

            //tworzenie roli
            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN",
            };

            adminRole.ConcurrencyStamp = adminRole.Id;

            //nadanie użytkownikowi roli 

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = adminRole.Id,
                        UserId = user.Id,
                    }
                );

            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole);


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
