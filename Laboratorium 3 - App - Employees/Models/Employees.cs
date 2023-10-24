using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App___Employees.Models
{
    public class Employees
    {
        //imię, nazwisko, pesel, stanowisko, oddział, data zatrudnienia, data zwolnienia
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Musisz podać imię!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Imię zbyt długie, maksymalnie 50 znaków!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Musisz podać nazwisko!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Nazwisko zbyt długie, maksymalnie 50 znaków!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Musisz podać pesel!")]
        [StringLength(maximumLength: 11, ErrorMessage = "Pesel ma 11 cyfr!")]
        public string Pesel { get; set; }

        [Required(ErrorMessage = "Musisz podać stanowisko!")]
        [StringLength(maximumLength: 11, ErrorMessage = "Stanowisko zbyt długie, maksymalnie 50 znaków!")]
        public string Stanowisko { get; set; }

        [Required(ErrorMessage = "Musisz podać oddział!")]
        [StringLength(maximumLength: 11, ErrorMessage = "Nazwa oddziału zbyt długa, maksymalnie 50 znaków!")]
        public string Department { get; set; }


        [Required(ErrorMessage = "Musisz podać datę zatrudnienia!")]
        public DateTime Hire { get; set; }

        public DateTime? Fire { get; set; }


    }
}
