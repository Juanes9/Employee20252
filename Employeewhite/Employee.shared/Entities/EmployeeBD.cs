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

        [MaxLength(30, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string FirstName { get; set; } = null!;

        [MaxLength(30, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string LastName { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime? HireDate { get; set; }

        [Range(1000000, double.MaxValue, ErrorMessage = "El valor minimo del campo {0} es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Salary { get; set; }
    }
}