using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartCityApi.Models
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        public int Populacao { get; set; }

        // Relacionamento com Zonas
        public ICollection<Zona> Zonas { get; set; }
    }
}
