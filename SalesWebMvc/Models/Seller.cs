using System;
using System.Linq;
using System.Collections.Generic;
using SalesWebMvc.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        public Departament Departament { get; set; }


        [Display(Name = "Departament Id")]
        public int DepartamentId { get; set; }
        public ICollection<SallesRecord> Salles { get; set; } = new List<SallesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }
        public void AddSalles(SallesRecord sr)
        {
            Salles.Add(sr);
        }
        public void RemoveSalles(SallesRecord sr)
        {
            Salles.Remove(sr);
        }
        public double TotalSalles(DateTime initial, DateTime final)
        {
            return Salles.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

        public static implicit operator Seller(string v)
        {
            throw new NotImplementedException();
        }
    }
}