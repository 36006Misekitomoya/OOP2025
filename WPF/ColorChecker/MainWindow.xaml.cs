using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorChecker {
    public partial class MainWindow : Window {
        // ListBoxアイテムの色情報を保持 (色と表示文字列)
        private List<(Color Color, string Display)> stockColors = new List<(Color, string)>();

        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
            UpdateColorAreaFromSliders();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors)
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .Select(p => new MyColor {
                    Color = (Color)p.GetValue(null),
                    Name = p.Name
                }).ToArray();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            UpdateColorAreaFromSliders();
        }

        private void UpdateColorAreaFromSliders() {
            int r = (int)rSlider.Value;
            int g = (int)gSlider.Value;
            int b = (int)bSlider.Value;
            colorArea.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
        }

        // リセットボタン
        private void Button_Click_1(object sender, RoutedEventArgs e) {
            stockListBox.Items.Clear();  // ListBoxのアイテムを全部クリア
            stockColors.Clear();         // 履歴を管理しているリストもクリア
        }

        private void Button_Click(object sender, RoutedEventArgs e) {            
            var sliderColor = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);

            if (ComboBox.SelectedItem is MyColor selectedColor) {
                if (selectedColor.Color == sliderColor) {
                    // 色が同じなら色名を追加（重複なければ）
                    if (!stockColors.Any(c => c.Display == selectedColor.Name)) {
                        stockColors.Add((selectedColor.Color, selectedColor.Name));
                        stockListBox.Items.Add(selectedColor.Name);
                    }
                } else {
                    // Sliderの色が違うならSlider値を追加
                    string display = $"R: {(int)rSlider.Value}    G: {(int)gSlider.Value}    B: {(int)bSlider.Value}";
                    if (!stockColors.Any(c => c.Display == display)) {
                        stockColors.Add((sliderColor, display));
                        stockListBox.Items.Add(display);
                    }
                }
            } else {
                // ComboBoxが選択されていなければSlider値を追加
                string display = $"R: {(int)rSlider.Value}    G: {(int)gSlider.Value}    B: {(int)bSlider.Value}";
                if (!stockColors.Any(c => c.Display == display)) {
                    stockColors.Add((sliderColor, display));
                    stockListBox.Items.Add(display);
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ComboBox.SelectedItem is MyColor selectedColor) {
                setSliderValue(selectedColor.Color);
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
            }
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void stockListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            int idx = stockListBox.SelectedIndex;
            if (idx >= 0 && idx < stockColors.Count) {
                Color selectedColor = stockColors[idx].Color;
                setSliderValue(selectedColor);
                colorArea.Background = new SolidColorBrush(selectedColor);
            }
        }       
    }
}
