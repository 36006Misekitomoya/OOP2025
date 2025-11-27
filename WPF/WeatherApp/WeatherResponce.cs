using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp {
    internal class WeatherResponce {
        public Current current_weather { get; set; }
        public Hourly hourly { get; set; }
    }

    public class Current {
        // 現在の天気データを格納
        public string time { get; set; }
        public double temperature_2m { get; set; }
        public double wind_speed_10m { get; set; }
        public double humidity_2m { get; set; }
    }

    public class Hourly {
        public List<string> time { get; set; }
        public List<double> temperature_2m { get; set; }
        public List<double> wind_speed_10m { get; set; }
        public List<double> relativehumidity_2m { get; set; }
    }
}