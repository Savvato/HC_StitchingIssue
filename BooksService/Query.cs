using BooksService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksService
{
    public class Query
    {
        private static readonly IEnumerable<Book> AllBooks = new[]
        {
            new Book
            {
                Id = Guid.Parse("fcdaa66f-dee1-4156-b1dc-f6b5d5c97538"),
                Title = "Book 1"
            },
            new Book
            {
                Id = Guid.Parse("eb380899-6a2c-4c89-a28f-4dc8dfbd3df6"),
                Title = "Book 2"
            },
            new Book
            {
                Id = Guid.Parse("207bc9c7-f0fe-4b88-9afc-6a00ae92ece8"),
                Title = "Book 3"
            },
        };

        public IEnumerable<Book> GetBooks(IEnumerable<Guid> bookIds) => AllBooks.Where(book => bookIds.Any(id => id == book.Id)).ToArray();
    }
}
