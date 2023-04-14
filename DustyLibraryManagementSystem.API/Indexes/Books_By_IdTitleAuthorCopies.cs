using DustyLibraryManagementSystem.Domain;
using Raven.Client.Documents.Indexes;

namespace DustyLibraryManagementSystem.API.Indexes
{
    public class Books_By_IdTitleAuthorCopies : AbstractIndexCreationTask<Book>
    {
        public Books_By_IdTitleAuthorCopies()
        {
            Map = (books) =>
                from book in books
                select new
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Copies = book.BookQuantity.Available
                };
        }
    };
}