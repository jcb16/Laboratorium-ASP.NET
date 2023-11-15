using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        private string Path { get; set; }
        
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Path = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"data source={Path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Contacts)
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

            modelBuilder.Entity<ContactEntity>().HasData(
                    new ContactEntity() { ID = 1, Name = "Adam", Email = "adam@onet.pl", Phone = "111222333", OrganizationID=102, },
                    new ContactEntity() { ID = 2, Name = "Kasia", Email = "kasia@onet.pl", Phone = "444555666", OrganizationID = 101, },
                    new ContactEntity() { ID = 3, Name = "Ada", Email = "ada@onet.pl", Phone = "777888999", OrganizationID = 102, }
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
