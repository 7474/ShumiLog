using System.ComponentModel.DataAnnotations;

namespace ShumiLog.Data.Model
{
    public class WeatherForecast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }
}
