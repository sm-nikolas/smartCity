using System.ComponentModel.DataAnnotations;

namespace SmartCityApi.Models
{
    public class Sensor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Tipo { get; set; }
        
        [Required]
        public string Localizacao { get; set; }
        
        // Chave estrangeira para Zona
        public int ZonaId { get; set; }
        public Zona Zona { get; set; }
    }
}
