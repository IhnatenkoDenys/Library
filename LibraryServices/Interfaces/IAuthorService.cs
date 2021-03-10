using LibraryServices.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryServices.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDTO> GetAuthorById(int id);

        Task<List<AuthorDTO>> GetAuthors();

        Task<List<AuthorDTO>> GetSpecificAuthorsByName(string name);

        Task<int> Create(AuthorDTO author);

        Task Update(AuthorDTO author);

        Task Delete(int id);
    }
}
