using Literature.Application.Dtos.Authors;
using Literature.Application.Dtos.Books;
using Literature.Domain.Entities;
using Mapster;

namespace Literature.Application.Mappings
{
    public class MappingProfile
    {
        public static void Configure()
        {
            TypeAdapterConfig<Author, AuthorModel>.NewConfig()
                .Map(dest => dest.BookId, src => src.IdBook);
            TypeAdapterConfig<CreateAuthorModel, Author>.NewConfig();
            TypeAdapterConfig<UpdateAuthorModel, Author>.NewConfig()
                .IgnoreNullValues(true);

            TypeAdapterConfig<Book, BookModel>.NewConfig();
            TypeAdapterConfig<CreateBookModel, Book>.NewConfig();
            TypeAdapterConfig<UpdateBookModel, Book>.NewConfig()
                .IgnoreNullValues(true);
        }
    }
}
