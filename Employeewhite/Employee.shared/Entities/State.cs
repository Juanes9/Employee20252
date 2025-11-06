using Employee.shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee.shared.Entities
{
    public class State : IEntityWithName
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [Display(Name = "Country")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }

        [JsonIgnore]
        public Country? Country { get; set; }

        public ICollection<City>? City { get; set; }

        public int NumberCities => City == null ? 0 : City.Count;
    }
}
