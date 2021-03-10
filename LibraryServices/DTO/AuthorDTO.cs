using System;
using System.Collections.Generic;

namespace LibraryServices.DTO
{
    public class AuthorDTO : BaseDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? CountryId { get; set; }

        public CountryDTO Country { get; set; }

        public List<AuthorBookDTO> AuthorBooks { get; set; }
    }
}
