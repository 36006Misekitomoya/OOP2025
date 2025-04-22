namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            //インチからメートル                              
            for (int inch = 1; inch <= 10; inch++) {
                // double meter = feet * 0.3048;                    
                double meter = InchToMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
            }
            //メートルからインチ                              
            for (int meter = 1; meter <= 10; meter++) {
                // double meter = feet * 0.3048;                    
                double inch = MeterToInch(meter);
                Console.WriteLine($"{meter}m = {inch:0.0000}inch");

            }
        }

        //フィートからメートルを求める
        public static double InchToMeter(int inch) {
            return inch * 0.0254;
        }
        //フィートからメートルを求める
        public static double MeterToInch(int meter) {
            return meter / 0.0254;
        }
    }
}

