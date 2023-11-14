using DataEmployees.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEmployees
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmployeesEntity> Employees { get; set; }
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
            modelBuilder.Entity<EmployeesEntity>().HasData(
                    new EmployeesEntity() { ID = 1, Name = "Adam", Surname="Kowalski", Pesel="11111111111", Stanowisko="CyberSecEngineer", Department = "IT", Hire=new DateTime(2012,8,6), Fire=new DateTime(2015,10,16), Created = new DateTime(2012,8,30) }
                    
                 
                );
        }
    }
}
