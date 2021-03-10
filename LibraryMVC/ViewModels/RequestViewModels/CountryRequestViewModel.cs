using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.ViewModels.RequestViewModels
{
    public class CountryRequestViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}'s lengths shuld be between {2} and {1}.")]
        public string Name { get; set; }
    }
}
