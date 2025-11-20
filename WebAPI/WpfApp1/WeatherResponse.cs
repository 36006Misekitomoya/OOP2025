namespace WeatherApp {
    public class WeatherResponse {
        public CurrentWeather current_weather { get; set; }
    }

    public class CurrentWeather {
        public string time { get; set; }
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public int weathercode { get; set; }
    }
}
