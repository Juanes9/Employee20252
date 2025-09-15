using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.shared.Entities
{
    public class EmployeeBD
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(30)]
        public string LastName { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime HireDate { get; set; }

        [Required, Range(1000000, double.MaxValue, ErrorMessage = "Salary must be at least 1,000,000.")]
        public decimal Salary { get; set; }
    }
}