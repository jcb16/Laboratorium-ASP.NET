using DataEmployees;
using Laboratorium_3___App___Employees.Mappers;
using DataEmployees.Entities;

namespace Laboratorium_3___App___Employees.Models
{
    public class EFEmployeesService : IEmployeesService
    {
        private readonly AppDbContext _context;

        public EFEmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Employees employees)
        {

            _context.Employees.Add(EmployeesMapper.ToEntity(employees));
            _context.SaveChanges();
        }

        public List<Employees> FindAll()
        {
            return _context.Employees.Select(e => EmployeesMapper.FromEntity(e)).ToList();

        }

        public List<OrganizationEntity> FindAllOrganization()
        {
            return _context.Organizations.ToList();
        }

        public Employees? FindByID(int id)
        {
            var find = _context.Employees.Find(id);
            return find is not null ? EmployeesMapper.FromEntity(find) : null;
        }


        public void RemoveById(int id)
        {
            var find = _context.Employees.Find(id);
            if (find != null)
            {
                _context.Employees.Remove(find);
                _context.SaveChanges();
            }
        }

        public void Update(Employees employees)
        {
            var entity = EmployeesMapper.ToEntity(employees);
            _context.Employees.Update(entity);
            _context.SaveChanges();

        }
    }
}

