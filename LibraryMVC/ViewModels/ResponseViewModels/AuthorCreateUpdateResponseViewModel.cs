using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.ViewModels.ResponseViewModels
{
    public class AuthorCreateUpdateResponseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Firts Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}'s lengths shuld be between {2} and {1}.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "{0}'s lengths shuld be between {2} and {1}.")]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int CountryId { get; set; }

        public List<SelectListItem> CountryItems { get; set; } = new List<SelectListItem>();
    }
}
