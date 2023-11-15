using Data.Entities;

namespace Laboratorium_3___App.Models
{
    public class ContactMapper
    {
        public static Contact FromEntity(ContactEntity entity)
        {
            return new Contact()
            {
                ID = entity.ID,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Birth = entity.Birth,
                OrganizationID = entity.OrganizationID,
            };
        }

        public static ContactEntity ToEntity(Contact model) {
            return new ContactEntity()
            {
                ID = model.ID,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Birth = model.Birth,
                OrganizationID = model.OrganizationID,
            };
        }
        //dane w /user/AppData/Local
    }
}
