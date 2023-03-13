using DustyLibraryManagementSystem.Domain;
using Raven.Client.Documents.Indexes;

namespace DustyLibraryManagementSystem.Indexes
{
    public class Books_ByTitleAndAuthor : AbstractIndexCreationTask<Book>
    {
        public Books_ByTitleAndAuthor()
        {
            Map = (books) =>
                from book in books
                select new
                {
                    Title = book.Title,
                    Author = book.Author
                };
        }
    }
}