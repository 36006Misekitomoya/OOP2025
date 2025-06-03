
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

        }

        private static void Exercise1(string text) {
            var s = text.Count(s => s == ' ');
            Console.WriteLine(s);
        }

        private static void Exercise2(string text) {
            var s = text.Replace("big", "small");
            Console.WriteLine(s);
        }

        private static void Exercise3(string text) {
            var words = text.Split(' ');
            var sb = new StringBuilder();
            foreach (var word in words) {
                sb.Append(word + " ");
            }
            var str = sb.ToString().TrimEnd();
            Console.WriteLine(str + ".");
        }

        private static void Exercise4(string text) {
            var s = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine(s);
        }

        private static void Exercise5(string text) {
            var s = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(s => s.Length <= 4 );
            foreach(var aaa in s)
            Console.WriteLine(aaa);
        }
    }
}
