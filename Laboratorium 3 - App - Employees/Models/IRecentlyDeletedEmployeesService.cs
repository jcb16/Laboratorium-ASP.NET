namespace Laboratorium_3___App___Employees.Models
{
    public interface IRecentlyDeletedEmployeesService
    {
        List<RecentlyDeletedEmployee> GetRecentlyDeletedEmployees();
        void Add(RecentlyDeletedEmployee employee);
        void RemoveOldDeletedEmployees(DateTime olderThan);
        List<RecentlyDeletedEmployee> GetDeletedEmployeesByDepartment(string departmentName);
        void RestoreDeletedEmployee(int employeeId);
        RecentlyDeletedEmployee GetDetailsOfDeletedEmployee(int employeeId);

    }
}
