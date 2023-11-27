using DataEmployees.Entities;
using Laboratorium_3___App___Employees.Models;
using Microsoft.SqlServer.Server;

namespace Laboratorium_3___App___Employees.Mappers
{
    public class EmployeesMapper
    {
        public static Employees FromEntity(EmployeesEntity entity)
        {
            return new Employees()
            {
                ID = entity.ID,
                Name = entity.Name,
                Surname = entity.Surname,
                Pesel = entity.Pesel,
                Stanowisko = entity.Stanowisko,
                Department = (Department)Enum.Parse(typeof(Department), entity.Department),
                Hire = entity.Hire,
                Fire = entity.Fire,
                Created = entity.Created,
                OrganizationID = entity.OrganizationID,
            };
        }

        public static EmployeesEntity ToEntity(Employees employees)
        {
            return new EmployeesEntity()
            {
                ID = employees.ID,
                Name = employees.Name,
                Surname = employees.Surname,
                Pesel = employees.Pesel,
                Stanowisko = employees.Stanowisko,
                Department = employees.Department.ToString(),
                Hire = employees.Hire,
                Fire = employees.Fire,
                Created = employees.Created,
                OrganizationID = employees.OrganizationID,
            };
        }
    }
}
