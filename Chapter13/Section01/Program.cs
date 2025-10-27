namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var groups = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderByDescending(g => g.Key);
            foreach (var group in groups) {
                Console.WriteLine($"{group.Key}年");
                foreach (var book in group) {
                    Console.WriteLine($"   {book}");
                }
            }
        }
    }
}
