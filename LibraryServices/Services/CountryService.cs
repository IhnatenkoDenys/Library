using AutoMapper;
using LibraryDataAccess.Entities;
using LibraryDataAccess.Interfaces;
using LibraryServices.DTO;
using LibraryServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryServices.Services
{
    public class CountryService : ICountryService
    {
        private readonly IAsyncRepository<Country> _repository;
        private readonly IMapper _mapper;

        public CountryService(IAsyncRepository<Country> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CountryDTO>> GetCountries()
        {
            return _mapper.Map<List<CountryDTO>>(await _repository.ListAllAsync());
        }
    }
}
