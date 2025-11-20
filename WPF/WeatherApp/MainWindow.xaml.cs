using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WeatherApp {
    public partial class MainWindow : Window {
        // 都道府県座標
        readonly Dictionary<string, (double lat, double lon)> cityCoords = new Dictionary<string, (double lat, double lon)>
{
            {"北海道", (43.06417, 141.34694)},
            {"青森", (40.82444, 140.74)},
            {"岩手", (39.70361, 141.1525)},
            {"宮城", (38.26889, 140.87194)},
            {"秋田", (39.71861, 140.1025)},
            {"山形", (38.24056, 140.36333)},
            {"福島", (37.75, 140.46778)},
            {"茨城", (36.34139, 140.44667)},
            {"栃木", (36.56583, 139.88361)},
            {"群馬", (36.39111, 139.06083)},
            {"埼玉", (35.85694, 139.64889)},
            {"千葉", (35.60472, 140.12333)},
            {"東京", (35.68944, 139.69167)},
            {"神奈川", (35.44778, 139.6425)},
            {"新潟", (37.90222, 139.02361)},
            {"富山", (36.69528, 137.21139)},
            {"石川", (36.59444, 136.62556)},
            {"福井", (36.06528, 136.22194)},
            {"山梨", (35.66389, 138.56833)},
            {"長野", (36.65139, 138.18111)},
            {"岐阜", (35.39111, 136.72222)},
            {"静岡", (34.97556, 138.38278)},
            {"愛知", (35.18028, 136.90667)},
            {"三重", (34.73028, 136.50861)},
            {"滋賀", (35.00444, 135.86833)},
            {"京都", (35.02139, 135.75556)},
            {"大阪", (34.68639, 135.52)},
            {"兵庫", (34.69139, 135.18306)},
            {"奈良", (34.68528, 135.83278)},
            {"和歌山", (34.22611, 135.1675)},
            {"鳥取", (35.50361, 134.23833)},
            {"島根", (35.47222, 133.05056)},
            {"岡山", (34.66167, 133.935)},
            {"広島", (34.39639, 132.45944)},
            {"山口", (34.18583, 131.47139)},
            {"徳島", (34.07028, 134.55444)},
            {"香川", (34.34028, 134.04333)},
            {"愛媛", (33.84167, 132.76556)},
            {"高知", (33.55972, 133.53111)},
            {"福岡", (33.60639, 130.41806)},
            {"佐賀", (33.24944, 130.29889)},
            {"長崎", (32.74472, 129.87361)},
            {"熊本", (32.78972, 130.74167)},
            {"大分", (33.23806, 131.6125)},
            {"宮崎", (31.91111, 131.42389)},
            {"鹿児島", (31.56028, 130.55778)},
            {"沖縄", (26.2125, 127.68111)}
        };

        public MainWindow() {
            InitializeComponent();
        }

        // 擬似プレースホルダー
        private void CityInput_GotFocus(object sender, RoutedEventArgs e) {
            if (CityInput.Text == "都市名を入力") {
                CityInput.Text = "";
                CityInput.Foreground = Brushes.Black;
            }
        }

        private void CityInput_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(CityInput.Text)) {
                CityInput.Text = "都市名を入力";
                CityInput.Foreground = Brushes.Gray;
            }
        }

        // 天気取得
        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e) {
            string city = CityInput.Text.Trim();
            if (string.IsNullOrEmpty(city) || !cityCoords.ContainsKey(city)) {
                MessageBox.Show("正しい都道府県名を入力してください");
                return;
            }

            var (lat, lon) = cityCoords[city];
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true";

            try {
                using (var http = new HttpClient()) {
                    string json = await http.GetStringAsync(url);
                    var response = JsonConvert.DeserializeObject<WeatherResponse>(json);

                    if (response?.current_weather != null) {
                        var w = response.current_weather;
                        TemperatureText.Text = $"{w.temperature}°C";
                        WindText.Text = $"風速: {w.windspeed} m/s";
                        DescriptionText.Text = $"更新: {w.time}";

                        // 修正
                        WeatherIcon.Text = GetWeatherIcon(w.weathercode);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"天気情報取得中にエラーが発生しました:\n{ex.Message}");
            }
        }

        private string GetWeatherIcon(int code)
{
    if (code == 0) return "☀️";       // 晴れ
    if (code <= 3) return "☁️";       // 曇り
    if (code <= 67) return "🌧️";      // 雨
    return "❄️";                       // 雪
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
