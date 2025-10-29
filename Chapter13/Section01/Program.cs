namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var groups = Library.Categories
                 .GroupJoin(Library.Books
                        , c => c.Id
                        , b => b.CategoryId,
                        (book, category) => new {
                            book.Title,
                            Category = category.Name,
                            book.PublishedYear
                        });
        }
    }
}
