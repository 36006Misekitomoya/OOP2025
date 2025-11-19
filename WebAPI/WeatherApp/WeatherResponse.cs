using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp {
    public class WeatherResponse {
        public Current current_weather { get; set; }
        public Hourly hourly { get; set; }
    }

    public class Hourly {
        public List<double> relativehumidity_2m { get; set; }
        public List<string> time { get; set; }
    }

}
