using Employee.shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.shared.Entities
{
    public class Country : IEntityWithName
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [Display(Name = "Country")]
        public string Name { get; set; } = null!;

        public ICollection<State>? State { get; set; }

        public int NumberStates => State == null ? 0 : State.Count;
    }
}
