using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEmployees.Entities
{
    [Table("employees")]
    public class EmployeesEntity
    {
        [Column("employee_id")]
        public int ID { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Surname { get; set; }

        [MaxLength(11)]
        [Required]
        public string Pesel { get; set; }

        [MaxLength(50)]
        public string Stanowisko { get; set; }

        [Required]
        public string Department { get; set; }


        [Required]
        public DateTime Hire { get; set; }

        public DateTime? Fire { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public OrganizationEntity? Organization { get; set; }
        public int? OrganizationID { get; set; }
    }
}
