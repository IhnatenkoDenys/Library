using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.ViewModels.ResponseViewModels
{
    public class AuthorDisplayResponseViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int CountryId { get; set; }

        public string Country { get; set; }
    }
}
