using DataEmployees.Entities;

namespace Laboratorium_3___App___Employees.Models
{
    public class MemoryEmployeesService : IEmployeesService/*, IRecentlyDeletedEmployeesService*/
    {
        private readonly Dictionary<int, Employees> _employees = new Dictionary<int, Employees>();
        
        private readonly List<RecentlyDeletedEmployee> _recentlyDeletedEmployees = new List<RecentlyDeletedEmployee>();
        
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



        //public List<RecentlyDeletedEmployee> GetRecentlyDeletedEmployees()
        //{
        //    return _recentlyDeletedEmployees;
        //}

        //public void Add(RecentlyDeletedEmployee employee)
        //{
        //    _recentlyDeletedEmployees.Add(employee);
        //}

        //public void RemoveOldDeletedEmployees(DateTime olderThan)
        //{
        //    _recentlyDeletedEmployees.RemoveAll(e => e.DeletedDate < olderThan);
        //}

        //public void RestoreDeletedEmployee(int employeeId)
        //{
        //    var employeeToRestore = _recentlyDeletedEmployees.FirstOrDefault(e => e.ID == employeeId);
        //    if (employeeToRestore != null)
        //    {
        //        _recentlyDeletedEmployees.Remove(employeeToRestore);
        //        // Przywróć pracownika z _employees do bieżących pracowników, jeśli to konieczne
        //    }
        //}

        //public RecentlyDeletedEmployee GetDetailsOfDeletedEmployee(int employeeId)
        //{
        //    return _recentlyDeletedEmployees.FirstOrDefault(e => e.ID == employeeId);
        //}

        //public List<RecentlyDeletedEmployee> GetDeletedEmployeesByDepartment(string departmentName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

