using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;

namespace WeatherApp {
    public partial class MainWindow : Window {
        readonly Dictionary<string, (double lat, double lon)> cityCoords = new()
        {
            {"ìåãû", (35.68944, 139.69167)},
            {"ëÂç„", (34.68639, 135.52)},
            {"ñkäCìπ", (43.06417, 141.34694)},
            {"ïüâ™", (33.60639, 130.41806)}
        };

        public MainWindow() {
            InitializeComponent();
        }

        private async void CitySelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if (!(CitySelector.SelectedItem is ComboBoxItem item)) return;

            string city = item.Content.ToString();

            var (lat, lon) = cityCoords[city];
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true";

            try {
                using var http = new HttpClient();
                var response = await http.GetFromJsonAsync<WeatherResponse>(url);

                if (response?.current_weather != null) {
                    var w = response.current_weather;

                    TemperatureText.Text = $"{w.temperature}ÅãC";
                    WindText.Text = $"ïóë¨: {w.windspeed} m/s";
                    DescriptionText.Text = $"çXêVéûçè {w.time}";

                    WeatherIcon.Source = new System.Windows.Media.Imaging.BitmapImage(
                        new Uri(GetWeatherIcon(w.weathercode), UriKind.Relative));
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetWeatherIcon(int code) {
            if (code == 0) return "Assets/sun.png";          // âıê∞
            if (code <= 3) return "Assets/cloud.png";        // ì‹ÇË
            if (code <= 67) return "Assets/rain.png";        // âJ
            return "Assets/snow.png";                        // ê·
        }
    }

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
