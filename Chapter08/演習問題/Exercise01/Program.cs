
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            var dict = new Dictionary<char, int>();
            foreach (var c in text.ToUpper()) {
                if ('A' <= c && c <= 'Z') {
                    if (dict.ContainsKey(c)) {
                        dict[c]++;
                    } else {
                        dict[c] = 1;
                    }
                }
            }
            foreach (var b in dict.OrderBy(b => b.Key)) {
                Console.WriteLine($"{b.Key}:{b.Value}");
            }
        }

        private static void Exercise2(string text) {
            var dict = new SortedDictionary<char, int>();
            foreach (var c in text.ToUpper()) {
                if ('A' <= c && c <= 'Z') {
                    if (dict.ContainsKey(c)) {
                        dict[c]++;
                    } else {
                        dict[c] = 1;
                    }
                }
            }
            foreach (var b in dict) {
                Console.WriteLine($"{b.Key}:{b.Value}");
            }
        }
    }
}
