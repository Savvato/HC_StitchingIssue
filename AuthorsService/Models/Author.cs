namespace AuthorsService.Models
{
    using System;
    using System.Collections.Generic;

    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Guid> BookIds { get; set; }
    }
}
