using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryDataAccess.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
    }
}
