using AutoMapper;
using LibraryDataAccess.Entities;
using LibraryMVC.ViewModels.RequestViewModels;
using LibraryMVC.ViewModels.ResponseViewModels;
using LibraryServices.DTO;

namespace LibraryMVC.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorRequestViewModel, AuthorDTO>().ReverseMap();
            CreateMap<AuthorDisplayResponseViewModel, AuthorDTO>().ReverseMap();
            CreateMap<CountryRequestViewModel, CountryDTO>().ReverseMap();
            CreateMap<BookRequestViewModel, BookDTO>().ReverseMap();

            CreateMap<AuthorCreateUpdateResponseViewModel, AuthorDTO>().ReverseMap();
            CreateMap<CountryResponseViewModel, CountryDTO>().ReverseMap();
            CreateMap<BookResponseViewModel, BookDTO>().ReverseMap();
            CreateMap<AuthorBookResponseViewModel, AuthorBookDTO>().ReverseMap();
            CreateMap<PublisherResponseViewModel, PublisherDTO>().ReverseMap();

            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<BookDTO, Book>().ReverseMap();
            CreateMap<CountryDTO, Country>().ReverseMap();
            CreateMap<PublisherDTO, Publisher>().ReverseMap();
            CreateMap<AuthorBookDTO, AuthorBook>().ReverseMap();
        }
    }
}
