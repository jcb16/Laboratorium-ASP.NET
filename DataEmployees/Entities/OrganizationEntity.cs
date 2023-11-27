using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataEmployees.Entities
{
    [Table("organizations")]
    public class OrganizationEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public ICollection<EmployeesEntity> Employees { get; }
    }
}
