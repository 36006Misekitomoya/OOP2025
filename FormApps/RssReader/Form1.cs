using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string>() {
            {"����","https://news.yahoo.co.jp/rss/categories/domestic.xml" },
            {"����","https://news.yahoo.co.jp/rss/categories/world.xml" },
            {"�o��","https://news.yahoo.co.jp/rss/categories/business.xml" },
            {"�G���^��","https://news.yahoo.co.jp/rss/categories/entertainment.xml" },
            {"�X�|�[�c","https://news.yahoo.co.jp/rss/categories/sports.xml" },
            {"IT","https://news.yahoo.co.jp/rss/categories/it.xml" },
            {"�Ȋw","https://news.yahoo.co.jp/rss/categories/science.xml" },
            {"���C�t","https://news.yahoo.co.jp/rss/categories/life.xml" },
            {"�n��","https://news.yahoo.co.jp/rss/categories/local.xml" },
        };

        public string HistoryFilePath { get; private set; }

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(cbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);

                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();


                //N�{�b�N�X�փ^�C�g����\��
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));

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