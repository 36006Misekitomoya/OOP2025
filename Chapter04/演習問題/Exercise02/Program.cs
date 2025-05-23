

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1();
            Console.WriteLine("---");
            Exercise2();
            Console.WriteLine("---");
            Exercise3();
        }

        private static void Exercise1() {
            var gou = Console.ReadLine();
            int number;
            if (int.TryParse(gou, out number)) {
                if (number < 0) {
                    Console.WriteLine("変換後: "+number);
                } else if ( number < 100) {
                    Console.WriteLine("変換後: "+number * 2);
                } else if ( number < 500) {
                    Console.WriteLine("変換後: "+number * 3);
                } else {
                    Console.WriteLine("変換後: "+number);
                }
                
                //        Console.WriteLine("変換成功: " + number);
                //} else {
                //    Console.WriteLine("変換失敗");
                //}
            }
        }

        private static void Exercise2() {
            
        }

        private static void Exercise3() {
            
        }
    }
}
