using DataEmployees;
using Laboratorium_3___App___Employees.Mappers;
using DataEmployees.Entities;

namespace Laboratorium_3___App___Employees.Models
{
    public class EFEmployeesService : IEmployeesService
    {
        private readonly AppDbContext _context;
        private readonly IDateTimeProvider _timeProvider;


        public EFEmployeesService(AppDbContext context,IDateTimeProvider timeProvider)
        {
            _context = context;
            _timeProvider = timeProvider;
        }

        public void Add(Employees employees)
        {
            //_context.Employees.Add(EmployeesMapper.ToEntity(employees));
            //_context.SaveChanges();

            employees.Created = _timeProvider.GetCurrentData(); // Ustawienie daty utworzenia
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

        public PagingList<Employees> FindPage(int page, int size)
        {
            return PagingList<Employees>.Create(
                (p, s) =>
                    _context.Employees
                    .OrderBy(c => c.Name)
                    .Skip((p - 1) * s)
                    .Take(s)
                    .Select(EmployeesMapper.FromEntity)
                    .ToList()
                ,
                page,
                size,
                _context.Employees.Count()
                );
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

        //
        //public IEnumerable<Employees> GetEmployeesByDepartment(string department)
        //{
        //    return _context.Employees
        //        .Where(e => e.Department == department)
        //        .Select(EmployeesMapper.FromEntity)
        //        .ToList();
        //}

        public void MoveToRecentlyDeleted(int employeeId)
        {
            var employeeToMove = _context.Employees.Find(employeeId);

            if (employeeToMove != null)
            {
                _context.Employees.Remove(employeeToMove);
                _context.SaveChanges();
            }
        }
    }
}

