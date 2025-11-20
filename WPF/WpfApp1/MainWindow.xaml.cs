using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WeatherApp {
    public partial class MainWindow : Window {
        // 都市座標
        readonly Dictionary<string, (double lat, double lon)> cityCoords = new()
        {
            {"東京", (35.68944, 139.69167)},
            {"大阪", (34.68639, 135.52)},
            {"北海道", (43.06417, 141.34694)},
            {"福岡", (33.60639, 130.41806)}
        };

        public MainWindow() {
            InitializeComponent();
        }

        // 都市選択時
        private async void CitySelector_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CitySelector.SelectedItem is not ComboBoxItem item) return;

            string city = item.Content.ToString();
            var (lat, lon) = cityCoords[city];

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true";

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
                MessageBox.Show($"天気情報取得中にエラーが発生しました:\n{ex.Message}");
            }
        }

        // 天気コードからアイコンパス
        private string GetWeatherIcon(int code) {
            if (code == 0) return "Assets/sun.png";     // 晴れ
            if (code <= 3) return "Assets/cloud.png";   // 曇り
            if (code <= 67) return "Assets/rain.png";   // 雨
            return "Assets/snow.png";                   // 雪
        }
    }

    // モデルクラス
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
