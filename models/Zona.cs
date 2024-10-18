using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartCityApi.Models
{
    public class Zona
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        // Chave estrangeira para Cidade
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        
        // Relacionamentos com Sensores e Eventos
        public ICollection<Sensor> Sensores { get; set; }
        public ICollection<Evento> Eventos { get; set; }
    }
}
