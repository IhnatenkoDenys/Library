using LibraryServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDTO>> GetCountries();
    }
}
