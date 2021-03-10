using AutoMapper;
using LibraryDataAccess.Entities;
using LibraryDataAccess.Interfaces;
using LibraryServices.DTO;
using LibraryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryServices.Services
{
    public class BookService : IBookService
    {
        private readonly IAsyncRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BookService(IAsyncRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(BookDTO book)
        {
            return await _repository.AddAsync(_mapper.Map<Book>(book));
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
        }

        public async Task<BookDTO> GetBookById(int id)
        {
            return _mapper.Map<BookDTO>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<BookDTO>> GetBooks()
        {
            return _mapper.Map<List<BookDTO>>(await _repository.ListAllAsync());
        }

        public async Task<List<BookDTO>> GetSpecificBooks(string title, DateTime? date)
        {
            Expression<Func<Book, bool>> predicate;

            if (!string.IsNullOrEmpty(title) && date != null)
            {
                predicate = book => book.Title.Contains(title) && book.ReleaseDate == date;
            }
            else if (!string.IsNullOrEmpty(title))
            {
                predicate = book => book.Title.Contains(title);
            }
            else if (date != null)
            {
                predicate = book => book.ReleaseDate == date;
            }
            else
            {
                predicate = book => true;
            }

            return _mapper.Map<List<BookDTO>>(await _repository.ListAllAsync(predicate));
        }

        public async Task Update(BookDTO book)
        {
            await _repository.UpdateAsync(_mapper.Map<Book>(book));
        }
    }
}
