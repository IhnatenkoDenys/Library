using LibraryServices.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryServices.Interfaces
{
    public interface IPublisherService
    {
        Task<List<PublisherDTO>> GetPublishers();
    }
}
