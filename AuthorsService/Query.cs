using AuthorsService.Models;
using System;
using System.Collections.Generic;

namespace AuthorsService
{
    public class Query
    {
        public IEnumerable<Author> GetAuthors() => new[]
        {
            new Author
            {
                Id = Guid.Parse("1131d422-1ca7-44ef-ba49-f198a53084ee"),
                Name = "Author 1",
                BookIds = new []
                {
                    Guid.Parse("fcdaa66f-dee1-4156-b1dc-f6b5d5c97538"),
                    Guid.Parse("eb380899-6a2c-4c89-a28f-4dc8dfbd3df6"),
                    Guid.Parse("207bc9c7-f0fe-4b88-9afc-6a00ae92ece8"),
                }
            },
            new Author
            {
                Id = Guid.Parse("838a2bd5-0ea1-4911-8617-4ebf79a3063a"),
                Name = "Author 2",
                BookIds = new Guid[0]
            }
        };
    }
}
