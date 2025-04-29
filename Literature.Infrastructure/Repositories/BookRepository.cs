using Literature.Domain.Entities;
using Literature.Domain.Repositories;
using Literature.Infrastructure.Contracts.Api;

namespace Literature.Infrastructure.Repositories
{
    internal sealed class BookRepository(IApiClient apiClient) : IBookRepository
    {
        private readonly IApiClient _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

        public Task<IEnumerable<Book>> GetAllAsync()
            => _apiClient.GetAsync<IEnumerable<Book>>("Books");

        public Task<Book> GetByIdAsync(int id)
            => _apiClient.GetAsync<Book>($"Books/{id}");

        public Task AddAsync(Book book)
            => _apiClient.PostAsync<Book>("Books", book);
        public Task UpdateAsync(Book book)
            => _apiClient.PutAsync($"Books/{book.Id}", book);

        public Task DeleteAsync(int id)
            => _apiClient.DeleteAsync($"Books/{id}");
    }
}
