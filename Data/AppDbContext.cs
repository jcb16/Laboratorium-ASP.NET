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
            modelBuilder.Entity<ContactEntity>().HasData(
                    new ContactEntity() { ID = 1, Name = "Adam", Email = "adam@onet.pl", Phone = "111222333"},
                    new ContactEntity() { ID = 2, Name = "Kasia", Email = "kasia@onet.pl", Phone = "444555666" },
                    new ContactEntity() { ID = 3, Name = "Ada", Email = "ada@onet.pl", Phone = "777888999" }
                );
        }
    }
}
