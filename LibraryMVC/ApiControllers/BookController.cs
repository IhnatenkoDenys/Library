using AutoMapper;
using LibraryMVC.ViewModels.RequestViewModels;
using LibraryMVC.ViewModels.ResponseViewModels;
using LibraryServices.DTO;
using LibraryServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryMVC.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(ILogger<BookController> logger, IBookService bookService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = _mapper.Map<List<BookResponseViewModel>>(await _bookService.GetBooks());

            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = _mapper.Map<BookResponseViewModel>
                (await _bookService.GetBookById(id));

            return Ok(book);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] BookSearchRequestViewModel bookRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            if (bookRequest.Title == null && bookRequest.ReleaseDate == null)
            {
                return BadRequest();
            }

            var book = _mapper.Map<List<BookResponseViewModel>>
                (await _bookService.GetSpecificBooks(bookRequest.Title, bookRequest.ReleaseDate));

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookRequestViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            int result = await _bookService.Create(_mapper.Map<BookDTO>(book));

            return Ok(result);
        }

        // PUT api/<BookController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BookRequestViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            await _bookService.Update(_mapper.Map<BookDTO>(book));

            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.Delete(id);
            return Ok(new { Id = id});
        }
    }
}
