using Data.Entities;

namespace Laboratorium_3___App.Models
{
    public interface IContactService
    {
        void Add(Contact contact);
        void RemoveById(int id);
        void Update(Contact contact);
        List<Contact> FindAll();
        Contact? FindById(int id);

        List<OrganizationEntity> FindAllOrganization();

    }
}
