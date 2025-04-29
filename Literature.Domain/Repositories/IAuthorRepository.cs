using Literature.Domain.Entities;

namespace Literature.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();

        Task<Author> GetByIdAsync(int id);

        Task<IEnumerable<Author>> GetByBookIdAsync(int bookId);

        Task AddAsync(Author author);

        Task UpdateAsync(Author author);

        Task DeleteAsync(int id);
    }
}
