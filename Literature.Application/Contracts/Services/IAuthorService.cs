using Literature.Application.Dtos.Authors;

namespace Literature.Application.Contracts.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorModel>> GetAllAuthorsAsync();

        Task<AuthorModel> GetAuthorByIdAsync(int id);

        Task<AuthorModel> CreateAuthorAsync(CreateAuthorModel authorModel);

        Task<IEnumerable<AuthorModel>> GetAuthorsByBookIdAsync(int bookId);

        Task UpdateAuthorAsync(UpdateAuthorModel authorModel);

        Task DeleteAuthorAsync(int id);
    }
}
