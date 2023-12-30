using DataEmployees.Entities;

namespace Laboratorium_3___App___Employees.Models
{
    public class MemoryEmployeesService : IEmployeesService
    {
        private readonly Dictionary<int, Employees> _employees = new Dictionary<int, Employees>();
        //private int id = 0;
        private int id = 1;

        IDateTimeProvider _timeProvider;

        public MemoryEmployeesService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public void Add(Employees employees)
        {
            employees.Created = _timeProvider.GetCurrentData();
            employees.ID = id++;
            _employees.Add(employees.ID, employees);
        }

        public List<Employees> FindAll()
        {
            return _employees.Values.ToList();
        }

        public Employees? FindByID(int id)
        {
            //return _employees[id];
            return _employees.ContainsKey(id) ? _employees[id] : null;
        }

        public void RemoveById(int id)
        {
            _employees.Remove(id);
        }

        public void Update(Employees employees)
        {
            if (_employees.ContainsKey(employees.ID))
            {
                _employees[employees.ID] = employees;
            }
        }
        



        public List<OrganizationEntity> FindAllOrganization()
        {
            throw new NotImplementedException();
        }


        public PagingList<Employees> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

    }
}

