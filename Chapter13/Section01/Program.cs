namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var books = Library.Books
                 .Join(Library.Categories
                        , book => book.CategoryId
                        , Category => Category.Id,
                        (book, category) => new {
                            book.Title,
                            Category = category.Name,
                            book.PublishedYear
                        });
        }
    }
}
