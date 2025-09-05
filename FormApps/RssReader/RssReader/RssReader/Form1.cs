using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();


          
            cbUrl.DisplayMember = "Key";
            cbUrl.ValueMember = "Value";
            
            cbUrl.Items.Add(new KeyValuePair<string, string>("国内", "https://news.yahoo.co.jp/rss/categories/domestic.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("国際", "https://news.yahoo.co.jp/rss/categories/world.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("経済", "https://news.yahoo.co.jp/rss/categories/business.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("エンタメ", "https://news.yahoo.co.jp/rss/categories/entertainment.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("スポーツ", "https://news.yahoo.co.jp/rss/categories/sports.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("IT", "https://news.yahoo.co.jp/rss/categories/it.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("科学", "https://news.yahoo.co.jp/rss/categories/science.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("ライフ", "https://news.yahoo.co.jp/rss/categories/life.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("地域", "https://news.yahoo.co.jp/rss/categories/local.xml"));                        

            // イベント登録
            btRegistration.Click += btRegistration_Click;　
            btDelete.Click += tbDelete_Click;
        }

        // フォームクラスのフィールドとして rssUrlDict を定義　
        private Dictionary<string, string> rssUrlDict = new Dictionary<string, string>
        {
    { "国内", "https://news.yahoo.co.jp/rss/categories/domestic.xml" },
    { "国際", "https://news.yahoo.co.jp/rss/categories/world.xml" },
    { "経済", "https://news.yahoo.co.jp/rss/categories/business.xml" },
    { "エンタメ", "https://news.yahoo.co.jp/rss/categories/entertainment.xml" },
    { "スポーツ", "https://news.yahoo.co.jp/rss/categories/sports.xml" },
    { "IT", "https://news.yahoo.co.jp/rss/categories/it.xml" },
    { "科学", "https://news.yahoo.co.jp/rss/categories/science.xml" },
    { "ライフ", "https://news.yahoo.co.jp/rss/categories/life.xml" },
    { "地域", "https://news.yahoo.co.jp/rss/categories/local.xml" }
};

        private async void btRssGet_Click_1(object sender, EventArgs e) {
            try {
                using (var hc = new HttpClient()) {
                    // コンボボックスで選択されたアイテムを取得
                    
                        var selected = (KeyValuePair<string, string>)cbUrl.SelectedItem;
                    
                    // getRssUrl メソッドに選択されたキーを渡して、対応するURLを取得
                    string rssUrl = getRssUrl(selected.Key);
                    if (string.IsNullOrEmpty(rssUrl)) {
                        MessageBox.Show("URLが見つかりません。");
                        return;
                    }

                    // RSSのXMLを取得
                    string xml = await hc.GetStringAsync(rssUrl);
                    XDocument xdoc = XDocument.Parse(xml);

                    // RSSを解析して必要な要素を取得
                    items = xdoc.Root.Descendants("item")
                        .Select(x => new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link")
                        }).ToList();

                    // リストボックスへタイトルを表示
                    lbTitles.Items.Clear();
                    items.ForEach(item => lbTitles.Items.Add(item.Title ?? "データなし"));
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"エラーが発生しました: {ex.Message}");
            }
        }

        private string getRssUrl(string key) {
            // もし、辞書にキーが存在すれば、対応するURLを返す
            if (rssUrlDict.ContainsKey(key)) {
                return rssUrlDict[key];
            }
            return null; // 辞書にキーが無ければ null を返す
        }






        private void lbTitles_Click(object sender, EventArgs e) {

            if (lbTitles.SelectedIndex < 0 || lbTitles.SelectedIndex >= items.Count) return;
            string link = items[lbTitles.SelectedIndex].Link;
            if (!string.IsNullOrEmpty(link)) {
                wvRssLink.Source = new Uri(link);
            }
        }

        //戻る
        private void btReturn_Click(object sender, EventArgs e) {
                wvRssLink.GoBack();
            
        }
        

        //進む
        private void btMove_Click(object sender, EventArgs e) {            
                wvRssLink.GoForward();                            
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btReturn.Enabled = wvRssLink.CanGoBack;
            btMove.Enabled = wvRssLink.CanGoForward;
        }

        

        // お気に入り登録
        private void btRegistration_Click(object sender, EventArgs e) {
            string url = tbFavorite.Text.Trim();
            if (string.IsNullOrEmpty(url)) {
                MessageBox.Show("登録するURLを入力してください。");
                return;
            }

            if (!cbUrl.Items.Contains(url)) {
                cbUrl.Items.Add(url);
                MessageBox.Show("お気に入りに登録しました。");
            } else {
                MessageBox.Show("すでに登録されています。");
            }
        }

        //お気に入り削除
        private void tbDelete_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedItem == null) {
                MessageBox.Show("削除するURLを選択してください。");
                return;
            }

            string url = cbUrl.SelectedItem.ToString();
            if (MessageBox.Show($"「{url}」を削除しますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                cbUrl.Items.Remove(url);
                if (cbUrl.Items.Count > 0) {
                    cbUrl.SelectedIndex = 0;
                }
            }
        }

        private void lbTitles_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void cbUrl_SelectedIndexChanged(object sender, EventArgs e) {

        }

      
    }
}
