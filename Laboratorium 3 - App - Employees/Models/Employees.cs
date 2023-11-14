using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Laboratorium_3___App___Employees.Models
{
    public enum Department
    {
        [Display(Name = "Dział IT")]
        IT,

        [Display(Name = "Dział księgowości")]
        Księgowość,

        [Display(Name = "Dział HR")]
        HR,

        [Display(Name = "Dział PR")]
        PR,

        [Display(Name = "Dział finansów")]
        Finanse
    }

    static public class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }

    public class Employees
    {
        //imię, nazwisko, pesel, stanowisko, oddział, data zatrudnienia, data zwolnienia
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Musisz podać imię!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Imię zbyt długie, maksymalnie 50 znaków!")]
        [Display(Name = "Imię:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Musisz podać nazwisko!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Nazwisko zbyt długie, maksymalnie 50 znaków!")]
        [Display(Name = "Nazwisko:")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Musisz podać pesel!")]
        [StringLength(maximumLength: 11, ErrorMessage = "Pesel ma 11 cyfr!")]
        [Display(Name = "Pesel:")]
        public string Pesel { get; set; }

        [Required(ErrorMessage = "Musisz podać stanowisko!")]
        [StringLength(maximumLength: 11, ErrorMessage = "Stanowisko zbyt długie, maksymalnie 50 znaków!")]
        [Display(Name = "Stanowisko:")]
        public string Stanowisko { get; set; }

        [Display(Name = "Dział:")]
        public Department Department { get; set; }


        [Required(ErrorMessage = "Musisz podać datę zatrudnienia!")]
        [Display(Name = "Data zatrudnienia:")]
        public DateTime Hire { get; set; }

        [Display(Name = "Data zwolnienia(opcjonalnie):")]
        public DateTime? Fire { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }

    }
}
