using System.ComponentModel;

namespace EFCoreNet.API
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        // 根据特性设置--设置参数的默认值
        [DefaultValue(false)]
        public bool? Enabled { get; set; }
    }
}