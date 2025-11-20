using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WeatherApp {
    public partial class MainWindow : Window {

        readonly Dictionary<string, (double lat, double lon)> cityCoords = new() {
            {"東京", (35.68944, 139.69167)},
            {"大阪", (34.68639, 135.52)},
            {"北海道", (43.06417, 141.34694)},
            {"福岡", (33.60639, 130.41806)}
        };

        public MainWindow() {
            InitializeComponent();
        }

        private async void CitySelector_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CitySelector.SelectedItem is not ComboBoxItem item) return;

            string city = item.Content.ToString();
            var (lat, lon) = cityCoords[city];

            string url =
                $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true";

            try {
                using var http = new HttpClient();
                var response = await http.GetFromJsonAsync<WeatherResponse>(url);

                if (response?.current_weather != null) {
                    var w = response.current_weather;

                    TemperatureText.Text = $"{w.temperature}°C";
                    WindText.Text = $"風速: {w.windspeed} m/s";
                    DescriptionText.Text = $"更新: {w.time}";

                    WeatherIcon.Source = new BitmapImage(
                        new Uri(GetWeatherIcon(w.weathercode), UriKind.Relative));
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private string GetWeatherIcon(int code) {
            if (code == 0) return "Assets/sun.png";
            if (code <= 3) return "Assets/cloud.png";
            if (code <= 67) return "Assets/rain.png";
            return "Assets/snow.png";
        }
    }
}
