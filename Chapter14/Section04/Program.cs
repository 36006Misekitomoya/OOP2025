using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Section04 {
    internal class Program {
        static async Task Main(string[] args) {
            HttpClient hc = new HttpClient();

            hc.DeleteFromJsonAsync
            await GetHtmlExample(hc)^^\ ;
        }

        static async Task GetHtmlExample(HttpClient httpClient) {
            var url = "https://www.yahoo.co.jp/";
            var text = await httpClient.GetStringAsync(url);
            Console.WriteLine(text);
        }
    }
}
