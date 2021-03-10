using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.ViewModels.ResponseViewModels
{
    public class BookResponseViewModel
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int CopiesNumber { get; set; }

        public int PublisherId { get; set; }

        public PublisherResponseViewModel Publisher { get; set; }

        public List<AuthorBookResponseViewModel> AuthorBooks { get; set; }
    }
}
