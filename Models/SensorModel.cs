using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MonitoramentoAmbientalEndpoints.Models
{
    [Table("SENSOR")]
    [Index(nameof(Nome), IsUnique = true)]
    public class SensorModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Localizacao { get; set; }
        public string Temperatura { get; set; }
        public string Umidade { get; set; }
    }
}
