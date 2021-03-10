using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.ViewModels.RequestViewModels
{
    public class BookRequestViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int CopiesNumber { get; set; }

        public int PublisherId { get; set; }

        public PublisherRequestViewModel Publisher { get; set; }

        public List<AuthorBookRequestViewModel> AuthorBooks { get; set; }
    }
}
