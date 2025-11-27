using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TenkiApp {

    public partial class MainWindow : Window {
        public class Prefecture {

            public string Name { get; set; }

            public double Lat { get; set; }

            public double Lon { get; set; }

        }

        private List<Prefecture> Prefectures = new List<Prefecture>

        {

    new Prefecture{Name="北海道",Lat=43.0618,Lon=141.3545},
    new Prefecture{Name="青森",Lat=40.82444,Lon=140.74},
    new Prefecture{Name="岩手",Lat=39.70361,Lon=141.1525},
    new Prefecture{Name="宮城",Lat=38.26889,Lon=140.87194},
    new Prefecture{Name="秋田",Lat=39.71861,Lon=140.1025},
    new Prefecture{Name="山形",Lat=38.24056,Lon=140.36333},
    new Prefecture{Name="福島",Lat=37.75,Lon=140.46778},
    new Prefecture{Name="茨城",Lat=36.34139,Lon=140.44667},
    new Prefecture{Name="栃木",Lat=36.56583,Lon=139.88361},
    new Prefecture{Name="群馬",Lat=36.3907,Lon=139.0603},
    new Prefecture{Name="埼玉",Lat=35.85694,Lon=139.64889},
    new Prefecture{Name="千葉",Lat=35.60472,Lon=140.12333},
    new Prefecture{Name="東京",Lat=35.6895,Lon=139.6917},
    new Prefecture{Name="神奈川",Lat=35.44778,Lon=139.6425},
    new Prefecture{Name="新潟",Lat=37.90222,Lon=139.02361},
    new Prefecture{Name="富山",Lat=36.69528,Lon=137.21139},
    new Prefecture{Name="石川",Lat=36.59444,Lon=136.62556},
    new Prefecture{Name="福井",Lat=36.06528,Lon=136.22194},
    new Prefecture{Name="山梨",Lat=35.66389,Lon=138.56833},
    new Prefecture{Name="長野",Lat=36.65139,Lon=138.18111},
    new Prefecture{Name="岐阜",Lat=35.39111,Lon=136.72222},
    new Prefecture{Name="静岡",Lat=34.97694,Lon=138.38306},
    new Prefecture{Name="愛知",Lat=35.18028,Lon=136.90667},
    new Prefecture{Name="三重",Lat=34.73028,Lon=136.50861},
    new Prefecture{Name="滋賀",Lat=35.00444,Lon=135.86833},
    new Prefecture{Name="京都",Lat=35.02139,Lon=135.75556},
    new Prefecture{Name="大阪",Lat=34.6937,Lon=135.5023},
    new Prefecture{Name="兵庫",Lat=34.69139,Lon=135.18306},
    new Prefecture{Name="奈良",Lat=34.68528,Lon=135.83278},
    new Prefecture{Name="和歌山",Lat=34.22611,Lon=135.1675},
    new Prefecture{Name="鳥取",Lat=35.50361,Lon=134.23833},
    new Prefecture{Name="島根",Lat=35.47222,Lon=133.05056},
    new Prefecture{Name="岡山",Lat=34.66167,Lon=133.935},
    new Prefecture{Name="広島",Lat=34.39639,Lon=132.45944},
    new Prefecture{Name="山口",Lat=34.18583,Lon=131.47139},
    new Prefecture{Name="徳島",Lat=34.06583,Lon=134.55944},
    new Prefecture{Name="香川",Lat=34.34028,Lon=134.04333},
    new Prefecture{Name="愛媛",Lat=33.84167,Lon=132.76556},
    new Prefecture{Name="高知",Lat=33.55972,Lon=133.53111},
    new Prefecture{Name="福岡",Lat=33.5902,Lon=130.4017},
    new Prefecture{Name="佐賀",Lat=33.24944,Lon=130.29889},
    new Prefecture{Name="長崎",Lat=32.74472,Lon=129.87361},
    new Prefecture{Name="熊本",Lat=32.78972,Lon=130.74167},
    new Prefecture{Name="大分",Lat=33.23806,Lon=131.6125},
    new Prefecture{Name="宮崎",Lat=31.91111,Lon=131.42389},
    new Prefecture{Name="鹿児島",Lat=31.56028,Lon=130.55806},
    new Prefecture{Name="沖縄",Lat=26.2125,Lon=127.68111},

};


        public MainWindow() {

            InitializeComponent();

            PrefCombo.ItemsSource = Prefectures;

            _ = SetCurrentLocationPrefecture(); // 起動時に現在地

            PrefCombo.SelectionChanged += PrefCombo_SelectionChanged;

        }


        private void OnLocateClick(object sender, RoutedEventArgs e) {
            // ここにボタンがクリックされたときの処理を追加
            MessageBox.Show("Locate button clicked!");
        }

        // 起動時にIPから現在地を推定して都道府県選択

        private async Task SetCurrentLocationPrefecture() {
            try {
                using (var http = new HttpClient()) {
                    // Send a GET request and get the raw JSON response as a string
                    var jsonResponse = await http.GetStringAsync("http://ip-api.com/json");

                    // Deserialize the JSON response into an IpApiResponse object
                    var loc = JsonConvert.DeserializeObject<IpApiResponse>(jsonResponse);

                    if (loc != null) {
                        double lat = loc.lat;
                        double lon = loc.lon;

                        Prefecture nearest = null;
                        double minDistance = double.MaxValue;

                        foreach (var p in Prefectures) {
                            double d = GetDistance(lat, lon, p.Lat, p.Lon);
                            if (d < minDistance) {
                                minDistance = d;
                                nearest = p;
                            }
                        }

                        if (nearest != null)
                            PrefCombo.SelectedItem = nearest;
                    }
                }
            }
            catch {
                PrefCombo.SelectedIndex = 0; // Default to 北海道 in case of failure
            }
        }


        private double GetDistance(double lat1, double lon1, double lat2, double lon2) {

            double dLat = (lat2 - lat1) * Math.PI / 180.0;

            double dLon = (lon2 - lon1) * Math.PI / 180.0;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +

                       Math.Cos(lat1 * Math.PI / 180.0) * Math.Cos(lat2 * Math.PI / 180.0) *

                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return 6371 * c;

        }

        public class IpApiResponse { public double lat { get; set; } public double lon { get; set; } }

        private async void PrefCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (PrefCombo.SelectedItem == null) return;

            Prefecture selected = (Prefecture)PrefCombo.SelectedItem;

            AreaTitle.Text = selected.Name;
            AreaTitle.Foreground = Brushes.MediumPurple;
            TimeText.Foreground = Brushes.MediumPurple;
            TempText.Foreground = Brushes.MediumPurple;
            WindText.Foreground = Brushes.MediumPurple;
            WindDirText.Foreground = Brushes.MediumPurple;
            StatusText.Foreground = new SolidColorBrush(Color.FromArgb(200, 180, 162, 255));

            string url = string.Format(format: MainWindowHelpers.UrlTemplate, selected.Lat, selected.Lon);

            using (var http = new HttpClient()) {
                try {
                    var jsonResponse = await http.GetStringAsync(url);

                    // APIレスポンスをログ出力
                    Console.WriteLine(jsonResponse); // デバッグ用にレスポンスを確認

                    var weather = JsonConvert.DeserializeObject<WeatherResponse>(jsonResponse);

                    if (weather?.current_weather != null) {
                        // 天気情報が正常に取得できている場合
                        TimeText.Text = $"取得時刻: {weather.current_weather.time}";
                        TempText.Text = $"気温: {weather.current_weather.temperature} ℃";
                        WindText.Text = $"風速: {weather.current_weather.windspeed} m/s";
                        WindDirText.Text = $"風向: {weather.current_weather.winddirection} °";
                        WeatherIcon.Text = GetWeatherEmoji(weather.current_weather.weathercode);
                        WeatherIcon.Foreground = Brushes.Orchid;

                        DrawGraph(weather);
                        ShowWeeklyForecast(weather, selected.Name);
                        UpdateMiniSummary(weather.current_weather);                      
                    } else {
                        StatusText.Text = "天気情報が取得できませんでした";
                    }
                }
                catch (Exception ex) {
                    // エラーが発生した場合
                    StatusText.Text = $"エラー: {ex.Message}";
                }
            }
        }




        private string GetWeatherEmoji(int code) {

            if (code == 0) return "☀️";

            if (code >= 1 && code <= 3) return "⛅";

            if (code >= 45 && code <= 48) return "🌫";

            if ((code >= 51 && code <= 67) || (code >= 80 && code <= 82)) return "🌧️";

            if (code >= 71 && code <= 77) return "❄️";

            if (code >= 95 && code <= 99) return "⛈️";

            return "☁️";

        }

        private string GetDayOfWeek(string date) {

            if (DateTime.TryParse(date, out DateTime dt))

                return dt.ToString("ddd");

            return "";

        }

        private readonly Random rnd = new Random();

        private void UpdateMiniSummary(CurrentWeather cw) {

            var summaries = new List<string>

{



};


            string randomSummary = summaries[rnd.Next(summaries.Count)];

            StatusText.Text = randomSummary;

            MiniTempText.Text = $"{cw.temperature} ℃";

            MiniWindText.Text = $"{cw.windspeed} m/s";

            MiniHumidityText.Text = $"湿度: - %";

            MiniWeatherIcon.Text = GetWeatherEmoji(cw.weathercode);

        }

       

    



           


        private void DrawGraph(WeatherResponse weather) {

            GraphCanvas.Children.Clear();

            if (weather.daily == null || weather.daily.temperature_2m_max.Count == 0) return;

            double width = GraphCanvas.ActualWidth > 0 ? GraphCanvas.ActualWidth : 400;

            double height = GraphCanvas.ActualHeight > 0 ? GraphCanvas.ActualHeight : 200;

            double yMargin = 30;

            double maxTemp = double.MinValue;

            double minTemp = double.MaxValue;

            foreach (var t in weather.daily.temperature_2m_max) maxTemp = Math.Max(maxTemp, t);

            foreach (var t in weather.daily.temperature_2m_min) minTemp = Math.Min(minTemp, t);

            int days = weather.daily.temperature_2m_max.Count;

            double xStep = width / (days - 1);

            TextBlock maxLegend = new TextBlock { Text = "最高気温", Foreground = Brushes.MediumPurple, FontWeight = FontWeights.Bold };

            Canvas.SetLeft(maxLegend, 10); Canvas.SetTop(maxLegend, 0);

            GraphCanvas.Children.Add(maxLegend);

            TextBlock minLegend = new TextBlock { Text = "最低気温", Foreground = Brushes.Orchid, FontWeight = FontWeights.Bold };

            Canvas.SetLeft(minLegend, 120); Canvas.SetTop(minLegend, 0);

            GraphCanvas.Children.Add(minLegend);

            for (int i = 0; i < days; i++) {

                double x = i * xStep;

                double yMax = height - ((weather.daily.temperature_2m_max[i] - minTemp) / (maxTemp - minTemp) * (height - 2 * yMargin)) - yMargin;

                double yMin = height - ((weather.daily.temperature_2m_min[i] - minTemp) / (maxTemp - minTemp) * (height - 2 * yMargin)) - yMargin;

                Ellipse eMax = new Ellipse { Width = 10, Height = 10, Fill = Brushes.MediumPurple };

                Canvas.SetLeft(eMax, x - 5); Canvas.SetTop(eMax, yMax - 5);

                GraphCanvas.Children.Add(eMax);

                Ellipse eMin = new Ellipse { Width = 10, Height = 10, Fill = Brushes.Orchid };

                Canvas.SetLeft(eMin, x - 5); Canvas.SetTop(eMin, yMin - 5);

                GraphCanvas.Children.Add(eMin);

                if (i > 0) {

                    Line lMax = new Line {

                        X1 = (i - 1) * xStep,

                        Y1 = height - ((weather.daily.temperature_2m_max[i - 1] - minTemp) / (maxTemp - minTemp) * (height - 2 * yMargin)) - yMargin,

                        X2 = x,

                        Y2 = yMax,

                        Stroke = Brushes.MediumPurple,

                        StrokeThickness = 3

                    };

                    GraphCanvas.Children.Add(lMax);

                    Line lMin = new Line {

                        X1 = (i - 1) * xStep,

                        Y1 = height - ((weather.daily.temperature_2m_min[i - 1] - minTemp) / (maxTemp - minTemp) * (height - 2 * yMargin)) - yMargin,

                        X2 = x,

                        Y2 = yMin,

                        Stroke = Brushes.Orchid,

                        StrokeThickness = 3

                    };

                    GraphCanvas.Children.Add(lMin);

                }

                string dateStr = weather.daily.time[i].Substring(5).Replace("-", "/");

                TextBlock dateLabel = new TextBlock {

                    Text = dateStr,

                    Foreground = Brushes.MediumPurple,

                    FontSize = 12

                };

                Canvas.SetLeft(dateLabel, x - 15);

                Canvas.SetTop(dateLabel, height - 15);

                GraphCanvas.Children.Add(dateLabel);

            }

        }

        private void ShowWeeklyForecast(WeatherResponse weather, string prefName) {

            WeeklyPanel.Children.Clear();

            if (weather.daily != null) {

                for (int i = 0; i < weather.daily.time.Count; i++) {

                    double max = weather.daily.temperature_2m_max[i];

                    double min = weather.daily.temperature_2m_min[i];

                    string emoji = GetWeatherEmoji(weather.daily.weathercode[i]);

                    string dayOfWeek = GetDayOfWeek(weather.daily.time[i]);

                    string dateStr = weather.daily.time[i].Substring(5).Replace("-", "/");

                    TextBlock dayBlock = new TextBlock {

                        Text = $"{prefName}\n{dayOfWeek} {dateStr}\n{emoji}\nMax: {max}℃\nMin: {min}℃",

                        Foreground = Brushes.MediumPurple,

                        FontSize = 16,

                        Margin = new Thickness(5),

                        Padding = new Thickness(10),

                        Background = new SolidColorBrush(Color.FromArgb(150, 230, 220, 255)), // 薄ラベンダー

                        TextAlignment = TextAlignment.Center,

                        Width = 100

                    };

                    WeeklyPanel.Children.Add(dayBlock);

                }

            }

        }

        private void Refresh_Click(object sender, RoutedEventArgs e) {

            PrefCombo_SelectionChanged(null, null);

        }

    }

    public class WeatherResponse {
        public CurrentWeather current_weather { get; set; }
        public DailyWeather daily { get; set; }
    }

    public class CurrentWeather {
        public string time { get; set; }
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public double winddirection { get; set; }
        public int weathercode { get; set; }
    }


    public class DailyWeather {

        public List<string> time { get; set; } = new List<string>();

        public List<double> temperature_2m_max { get; set; } = new List<double>();

        public List<double> temperature_2m_min { get; set; } = new List<double>();

        public List<int> weathercode { get; set; } = new List<int>();

    }

}

