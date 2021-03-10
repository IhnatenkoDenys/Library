using AutoMapper;
using LibraryDataAccess.Entities;
using LibraryDataAccess.Interfaces;
using LibraryServices.DTO;
using LibraryServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryServices.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IAsyncRepository<Publisher> _repository;
        private readonly IMapper _mapper;

        public PublisherService(IAsyncRepository<Publisher> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PublisherDTO>> GetPublishers()
        {
            return _mapper.Map<List<PublisherDTO>>(await _repository.ListAllAsync());
        }
    }
}
