using Literature.Domain.Entities;
using Literature.Domain.Repositories;
using Literature.Infrastructure.Contracts.Api;

namespace Literature.Infrastructure.Repositories
{
    internal sealed class AuthorRepository(IApiClient apiClient) : IAuthorRepository
    {
        private readonly IApiClient _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

        public Task<IEnumerable<Author>> GetAllAsync()
            => _apiClient.GetAsync<IEnumerable<Author>>("Authors");

        public Task<Author> GetByIdAsync(int id)
            => _apiClient.GetAsync<Author>($"Authors/{id}");

        public Task<IEnumerable<Author>> GetByBookIdAsync(int bookId)
            => _apiClient.GetAsync<IEnumerable<Author>>($"Authors/authors/books/{bookId}");

        public Task AddAsync(Author author)
            => _apiClient.PostAsync<Author>("Authors", author);

        public Task UpdateAsync(Author author)
            => _apiClient.PutAsync($"Authors/{author.Id}", author);

        public Task DeleteAsync(int id)
            => _apiClient.DeleteAsync($"Authors/{id}");
    }
}
