using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string>() {
            {"国内","https://news.yahoo.co.jp/rss/categories/domestic.xml" },
            {"国際","https://news.yahoo.co.jp/rss/categories/world.xml" },
            {"経済","https://news.yahoo.co.jp/rss/categories/business.xml" },
            {"エンタメ","https://news.yahoo.co.jp/rss/categories/entertainment.xml" },
            {"スポーツ","https://news.yahoo.co.jp/rss/categories/sports.xml" },
            {"IT","https://news.yahoo.co.jp/rss/categories/it.xml" },
            {"科学","https://news.yahoo.co.jp/rss/categories/science.xml" },
            {"ライフ","https://news.yahoo.co.jp/rss/categories/life.xml" },
            {"地域","https://news.yahoo.co.jp/rss/categories/local.xml" },
        };

        public string HistoryFilePath { get; private set; }

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(cbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();


                //Nボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "データなし"));

            }
        }


        private void lbTitles_Click(object sender, EventArgs e) {
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
            btGoBack.Enabled = false;
            btGoForward.Enabled = true;

            //int index = lbTitles.SelectedIndex;
            //if (index >= 0 && index < items.Count) {
            //    string? link = items[index].Link;
            //    if(!string.IsNullOrEmpty(link)) {
            //        webView21.Source = new Uri(link);
            //    }
            //}
        }

        private void GoForwardBtEnableSet() {
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        }

        private void btGoForward_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoForward) {
                wvRssLink.GoForward();
            }
        }

        private void btGoBack_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoBack) {
                wvRssLink.GoBack();
            }
        }

        private void cbUrl_TextChanged(object sender, EventArgs e) {
            
        }
        private void cbUrlHistory_SelectedIndexChanged(object sender, EventArgs e) {
            cbUrl.Text = cbUrl.SelectedItem.ToString();
        }
    }
}