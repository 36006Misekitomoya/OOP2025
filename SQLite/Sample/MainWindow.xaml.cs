using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Sample {
    public partial class MainWindow : Window {
        // 顧客情報のモデル
        public class Customer {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string ImagePath { get; set; }  // 画像のパス
        }

        // 顧客リストを保持する ObservableCollection
        public ObservableCollection<Customer> Customers { get; set; }

        public MainWindow() {
            InitializeComponent();
            Customers = new ObservableCollection<Customer>();
            PersonListView.ItemsSource = Customers;
        }

        // 画像ファイルを選択して顧客情報に追加する
        private void ReadButton_Click(object sender, RoutedEventArgs e) {
            // 画像ファイルを選択するダイアログ
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "画像ファイル|*.jpg;*.jpeg;*.png;*.gif"
            };

            if (openFileDialog.ShowDialog() == true) {
                // 画像のパスを取得
                string imagePath = openFileDialog.FileName;

                // 顧客情報の追加（仮のデータ）
                var customer = new Customer {
                    Id = (Customers.Count + 1).ToString(), // 自動でIDを生成
                    Name = NameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    ImagePath = imagePath
                };

                // 顧客リストに追加
                Customers.Add(customer);
            }
        }

        // 保存ボタンの処理（実際の保存処理は仮実装）
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("顧客情報を保存しました。", "保存", MessageBoxButton.OK, MessageBoxImage.Information);
            // 実際の保存処理をここで実装（例：データベースへの保存やファイルへの書き込みなど）
        }

        // 削除ボタンの処理
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            // 選択された顧客を削除
            var selectedCustomer = PersonListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                Customers.Remove(selectedCustomer);
                MessageBox.Show("顧客情報を削除しました。", "削除", MessageBoxButton.OK, MessageBoxImage.Information);
            } else {
                MessageBox.Show("削除する顧客を選択してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 更新ボタンの処理（名前を変更する）
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = PersonListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                // 名前と電話番号を更新
                selectedCustomer.Name = NameTextBox.Text;
                selectedCustomer.Phone = PhoneTextBox.Text;

                // ListView を更新
                PersonListView.Items.Refresh();

                MessageBox.Show("顧客情報を更新しました。", "更新", MessageBoxButton.OK, MessageBoxImage.Information);
            } else {
                MessageBox.Show("更新する顧客を選択してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // ListView の選択が変更されたときに、選択した顧客の情報をフォームに表示
        private void PersonListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            var selectedCustomer = PersonListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                // 選択した顧客の情報を TextBox にセット
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
            }
        }
    }
}
