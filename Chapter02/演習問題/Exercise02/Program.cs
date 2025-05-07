namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("*** 変換アプリ ***");
            Console.WriteLine("1:ヤードからメートル");
            Console.WriteLine("2:メートルからヤード");
            int a = int.Parse(Console.ReadLine());

            if (a == 1) {
                Console.Write("変換前(ヤード):");
                int start = int.Parse(Console.ReadLine());
                Console.Write("変換後(ヤード):" + YardToMeter(int yard));
               
            } else if(a == 2) {
                Console.Write("変換前(メートル):");
                int start = int.Parse(Console.ReadLine());
                Console.Write("変換後(メートル):" + MeterToYard(int meter));
               
               
            } else {
                Console.WriteLine("エラー");
            }

        }
        //static void PrintYardToMeterList(int start, int end) {
        //    //インチからメートル                              
        //    for (int yard = start; yard <= end; yard++) {
        //        double meter = InchToMeter(yard);
        //        Console.WriteLine($"{yard}yard = {meter:0.0000}m");
        //    }
        //}
        //static void PrintMeterToYardList(int start, int end) {
        //    //メートルからインチ                              
        //    for (int meter = start; meter <= end; meter++) {
        //        double yard = MeterToInch(meter);
        //        Console.WriteLine($"{meter}m = {yard:0.0000}yard");

        //    }
        //}
        ////からメートルを求める
        public static double YardToMeter(int yard) {
            return yard * 0.9144;
        }
        //メートルからを求める
        public static double MeterToYard(int meter) {
            return meter / 0.9144;
        }
    }
}


