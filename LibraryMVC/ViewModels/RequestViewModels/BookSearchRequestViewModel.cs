using System;

namespace LibraryMVC.ViewModels.RequestViewModels
{
    public class BookSearchRequestViewModel
    {
        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
