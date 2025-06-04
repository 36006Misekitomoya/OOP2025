
using System.Runtime.CompilerServices;
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region
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

            Console.WriteLine("6.3.99");
            Exercise6(text);
            #endregion
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
            var s = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(s => s.Length <= 4);
            foreach (var aaa in s)
                Console.WriteLine(aaa);
        }
        private static void Exercise6(string text) {
            //text.ToLower()
            //    .Where(c => !char.IsWhiteSpace(c) && !char.IsPunctuation(c))
            //    .GroupBy(c => c)
            //    .OrderBy(g => g.Key)
            //    .ToList()
            //    .ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()}"));

            var str = text.ToLower().Replace(" ","");

            var alphDicCount = Enumerable.Range('a', 26)
                .ToDictionary(num => ((char)num).ToString(), num => 0);

            foreach (var alph in str) {
                alphDicCount[alph.ToString()]++;
            }
            foreach(var item in alphDicCount) {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
            Console.WriteLine();

            //*************************************************//
            //配列で集計
            var array = Enumerable.Repeat(0, 26).ToArray();

            foreach(var alph in str) {
                array[alph - 'a']++;
            }

            for (char ch = 'a';ch <= 'z'; ch++) {
                Console.WriteLine($"{ch}:{array[ch - 'a']}");
            }

            Console.WriteLine();
            //*************************************************//
            //'a'から順にカウントして出力
            for (char ch = 'a';ch <= 'z'; ch++) {
                Console.WriteLine($"{ch}:{text.Count(tc => tc == ch)}");
            }




        }
    }
}






