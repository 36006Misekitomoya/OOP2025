namespace LinqSample {
    internal class Program {
        static void Main(string[] args) {

            var numbers = Enumerable.Range(1, 100);

            //合計値を出力
            Console.WriteLine(numbers.Where(n => n % 8 == 0).Sum());

            ////偶数の合計を出力            
            //Console.WriteLine(numbers.Where(n => n % 2 == 0).Sum());

            ////偶数の一番大きい値を出力
            //Console.WriteLine(numbers.Where(n => n % 2 == 0).Max());

            ////偶数の一番小さい値を出力
            //Console.WriteLine(numbers.Where(n => n % 2 == 0).Min());


            ////平均を出力
            //Console.WriteLine(numbers.Average());

            //foreach(var num in numbers) {
            //    Console.WriteLine(num);
            //}
        }
    }
}
