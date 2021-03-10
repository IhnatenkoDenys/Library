using System;
using System.Collections.Generic;

namespace LibraryServices.DTO
{
    public class BookDTO : BaseDTO
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int CopiesNumber { get; set; }

        public int PublisherId { get; set; }

        public PublisherDTO Publisher { get; set; }

        public List<AuthorBookDTO> AuthorBooks { get; set; }
    }
}
