using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Laboratorium_3___App.Models
{
    static public class EnumExtension
    {
        static public string GetDisplayName(this Enum e)
        {
            return e.GetType()
                .GetMember(e.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }

    public enum Priority
    {
        [Display(Name = "Niski")]
        Low,
        [Display(Name = "Normalny")]
        Normal,
        [Display(Name = "Pilny")]
        Urgent
    }
    public class Contact
    {
        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }



        [HiddenInput]
        public int ID { get; set; }
        [Display(Name="Imię")]
        [Required(ErrorMessage ="Musisz podać imię!")]
        [StringLength(maximumLength:50, ErrorMessage ="Imię zbyt długie, maksymalnie 50 znaków!")]
        public string Name { get; set; }

        [Display(Name = "Adres email")]
        [EmailAddress(ErrorMessage = "Musisz podać poprawny email (brak znaku @)")]
        public string Email { get; set; }

        [Display(Name = "Numer telefonu")]
        [Phone(ErrorMessage ="Numer telefonu powinien zawierać cyfry")]
        public string Phone { get; set; }

        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birth {  get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }

        public int? OrganizationID { get; set; }

        [ValidateNever]
        public List<SelectListItem> OrganizationsList { get; set; }
    }
}
