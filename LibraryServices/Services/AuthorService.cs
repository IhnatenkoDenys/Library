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
    public class AuthorService : IAuthorService
    {
        private readonly IAsyncRepository<Author> _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAsyncRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(AuthorDTO author)
        {
            return  await _repository.AddAsync(_mapper.Map<Author>(author));
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
        }

        public async Task<AuthorDTO> GetAuthorById(int id)
        {
            return _mapper.Map<AuthorDTO>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<AuthorDTO>> GetAuthors()
        {
            return _mapper.Map<List<AuthorDTO>>(await _repository.ListAllAsync());
        }

        public async Task<List<AuthorDTO>> GetSpecificAuthorsByName(string name)
        {
            Expression<Func<Author, bool>> authorPredicate;

            if (!string.IsNullOrEmpty(name))
            {
                authorPredicate = author => author.FirstName.Contains(name);

                return _mapper.Map<List<AuthorDTO>>(await _repository.ListAllAsync(authorPredicate));
            }

            return await GetAuthors();
        }

        public async Task Update(AuthorDTO author)
        {
            await _repository.UpdateAsync(_mapper.Map<Author>(author));
        }
    }
}
