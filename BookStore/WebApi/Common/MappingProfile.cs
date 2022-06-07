using AutoMapper;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
using WebApi.Enum;

namespace WebApi.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();

            /*
            CreateMap<Book, BooksViewModel>()  
                .ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            */

            CreateMap<Genre, GenreViewModel>();

            ///

        }

    }
}
