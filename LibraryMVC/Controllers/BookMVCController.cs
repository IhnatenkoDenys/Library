using AutoMapper;
using LibraryMVC.ViewModels.ResponseViewModels;
using LibraryServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryMVC.Controllers
{
    public class BookMVCController : Controller
    {
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;

        public BookMVCController(IPublisherService publisherService, IMapper mapper)
        {
            _publisherService = publisherService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AddEdit(int id)
        {
            var publishersList = new SelectList(_mapper.Map<List<PublisherResponseViewModel>>(await _publisherService.GetPublishers()), "Id", "Name");

            var addEditBook = new BookMVCCreateUpdateViewModel
            {
                Id = id,
                Publishers = publishersList
            };

            return View(addEditBook);
        }
    }
}
