namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("*** 変換アプリ ***");
            Console.WriteLine("1:インチからメートル");
            Console.WriteLine("2:メートルからインチ");
            int a = int.Parse(Console.ReadLine());

            if (a == 1) {
                Console.Write("はじめ:");
                int start = int.Parse(Console.ReadLine());
                Console.Write("おわり:");
                int end = int.Parse(Console.ReadLine());
                PrintInchToMeterList(start, end);
            } else if(a == 2) {
                Console.Write("はじめ:");
                int start = int.Parse(Console.ReadLine());
                Console.Write("おわり:");
                int end = int.Parse(Console.ReadLine());
                PrintMeterToInchList(start, end);
            } else {
                Console.WriteLine("エラー");
            }

        }
        static void PrintInchToMeterList(int start, int end) {
            //インチからメートル                              
            for (int inch = start; inch <= end; inch++) {
                double meter = InchToMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
            }
        }
         static void PrintMeterToInchList(int start, int end) {
            //メートルからインチ                              
            for (int meter = start; meter <= end; meter++) {
                double inch = MeterToInch(meter);
                Console.WriteLine($"{meter}m = {inch:0.0000}inch");

            }
        }
        //インチからメートルを求める
        public static double InchToMeter(int inch) {
            return inch * 0.0254;
        }
        //メートルからインチを求める
        public static double MeterToInch(int meter) {
            return meter / 0.0254;
        }
    }
}


