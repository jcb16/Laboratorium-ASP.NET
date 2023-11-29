using Data;
using Data.Entities;

namespace Laboratorium_3___App.Models
{
    public class EFContactService : IContactService
    {
        private readonly  AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public List<OrganizationEntity> FindAllOrganization()
        {
            return _context.Organizations.ToList();
        }

        public Contact? FindById(int id)
        {
            var find = _context.Contacts.Find(id);
            return find is not null ? ContactMapper.FromEntity(find) : null;
        }

        public PagingList<Contact> FindPage(int page, int size)
        {
            return PagingList<Contact>.Create(
                (p,s) =>
                    _context.Contacts
                    .OrderBy(c => c.Name)
                    .Skip((p -1)*s)
                    .Take(s)
                    .Select(ContactMapper.FromEntity)
                    .ToList()
                ,
                page,
                size,
                _context.Contacts.Count()
                ) ;
        }

        public void RemoveById(int id)
        {
            var find = _context.Contacts.Find(id);
            if(find != null)
            {
                _context.Contacts.Remove(find);
                _context.SaveChanges();
            }
        }

        public void Update(Contact contact)
        {
            var entity = ContactMapper.ToEntity(contact);
            _context.Contacts.Update(entity);
            _context.SaveChanges();

        }
    }
}
