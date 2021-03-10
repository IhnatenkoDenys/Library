using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LibraryMVC.ViewModels.ResponseViewModels
{
    public class BookMVCCreateUpdateViewModel
    {
        public int Id { get; set; }

        public SelectList Publishers { get; set; }
    }
}
