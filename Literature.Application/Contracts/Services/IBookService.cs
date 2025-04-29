using Literature.Application.Dtos.Books;

namespace Literature.Application.Contracts.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetAllBooksAsync();

        Task<BookModel> GetBookByIdAsync(int id);

        Task<BookModel> CreateBookAsync(CreateBookModel bookDto);

        Task UpdateBookAsync(UpdateBookModel bookDto);

        Task DeleteBookAsync(int id);
    }
}
