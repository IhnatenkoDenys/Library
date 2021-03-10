using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.ViewModels.ResponseViewModels
{
    public class PublisherResponseViewModel
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
