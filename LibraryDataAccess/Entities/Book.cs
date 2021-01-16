using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryDataAccess.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        [StringLength(800)]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int CopiesNumber { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
    }
}
