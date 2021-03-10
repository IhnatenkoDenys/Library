using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.ViewModels.RequestViewModels
{
    public class AuthorBookRequestViewModel
    {
        public int BookId { get; set; }

        public BookRequestViewModel Book { get; set; }

        public int AuthorId { get; set; }

        public AuthorRequestViewModel Author { get; set; }
    }
}
