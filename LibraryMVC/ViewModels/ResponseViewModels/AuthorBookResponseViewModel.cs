using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.ViewModels.ResponseViewModels
{
    public class AuthorBookResponseViewModel
    {
        public int BookId { get; set; }

        public BookResponseViewModel Book { get; set; }

        public int AuthorId { get; set; }

        public AuthorDisplayResponseViewModel Author { get; set; }
    }
}
