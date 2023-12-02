using DataEmployees.Entities;

namespace Laboratorium_3___App___Employees.Models
{
    public interface IEmployeesService
    {
        void Add(Employees employee);
        void RemoveById(int id);
        void Update(Employees employee);
        List<Employees> FindAll();
        Employees? FindByID(int id);
        PagingList<Employees> FindPage(int page, int size);

        List<OrganizationEntity> FindAllOrganization();

    }
}
