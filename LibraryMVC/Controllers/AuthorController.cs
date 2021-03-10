using AutoMapper;
using LibraryMVC.ViewModels.RequestViewModels;
using LibraryMVC.ViewModels.ResponseViewModels;
using LibraryServices.DTO;
using LibraryServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService _authorService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService, ICountryService countryService, IMapper mapper) 
            : base(logger)
        {
            _logger = logger;
            _authorService = authorService;
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authoresList = _mapper.Map<List<AuthorDisplayResponseViewModel>>(await _authorService.GetAuthors());

            var countries = _mapper.Map<List<CountryResponseViewModel>>(await _countryService.GetCountries());

            authoresList.ForEach(x => {
                x.Country = countries.Where(y => y.Id == x.CountryId).Select(y => y.Name).FirstOrDefault();
            });

            return View(authoresList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorRequestViewModel author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.Create(_mapper.Map<AuthorDTO>(author));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AuthorRequestViewModel author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.Update(_mapper.Map<AuthorDTO>(author));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int id)
        {
            var countries = _mapper.Map<List<CountryResponseViewModel>>(await _countryService.GetCountries());

            var author = _mapper.Map<AuthorCreateUpdateResponseViewModel>(await _authorService.GetAuthorById(id))
                         ?? new AuthorCreateUpdateResponseViewModel();

            countries.ForEach(x => {
                author.CountryItems.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            });

            if (author.Id != 0)
            {
                var selected = author.CountryItems.Where(x => x.Value == author.CountryId.ToString()).FirstOrDefault();
                selected.Selected = true;
            }
            
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var author = _mapper.Map<AuthorDisplayResponseViewModel>(await _authorService.GetAuthorById(id));

            var countries = _mapper.Map<List<CountryResponseViewModel>>(await _countryService.GetCountries());

            author.Country = countries.FirstOrDefault(x => x.Id == author.CountryId)?.Name;

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AuthorRequestViewModel author)
        {
            await _authorService.Delete(author.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
