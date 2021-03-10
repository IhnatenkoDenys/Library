using LibraryServices.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryServices.Interfaces
{
    public interface IBookService
    {
        Task<BookDTO> GetBookById(int id);

        Task<List<BookDTO>> GetBooks();

        Task<List<BookDTO>> GetSpecificBooks(string title, DateTime? date);

        Task<int> Create(BookDTO author);

        Task Update(BookDTO author);

        Task Delete(int id);
    }
}
