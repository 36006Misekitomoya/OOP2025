namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {


            Product ydaihuku = new Product(124, "雪見大福", 500);
            Product karinto = new Product(123, "かりんとう", 180);

            //税抜き価格を表示
            Console.WriteLine( karinto.Name + "の税抜き価格は" + karinto.Price + "円です");
            //消費税額の表示
            Console.WriteLine(karinto.Name + "の消費税額は" + karinto.GetTax() + "円です");
            //税込み価格を表示
            Console.WriteLine(karinto.Name + "の税込み価格は" + karinto.GetPriceIncludingTax() + "円です");
         
            //税抜き価格を表示
            Console.WriteLine(ydaihuku.Name + "の税抜き価格は" + ydaihuku.Price + "円です");
            //消費税額の表示
            Console.WriteLine(ydaihuku.Name + "の消費税額は" + ydaihuku.GetTax() + "円です");
            //税込み価格を表示
            Console.WriteLine(ydaihuku.Name + "の税込み価格は" + ydaihuku.GetPriceIncludingTax() + "円です");

        }
    }
}
