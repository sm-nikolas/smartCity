using System;
using System.ComponentModel.DataAnnotations;

namespace SmartCityApi.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Descricao { get; set; }
        
        [Required]
        public DateTime DataHora { get; set; }
        
        // Chave estrangeira para Zona
        public int ZonaId { get; set; }
        public Zona Zona { get; set; }
    }
}
