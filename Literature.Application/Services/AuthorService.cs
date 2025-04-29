using Literature.Application.Contracts.Services;
using Literature.Application.Dtos.Authors;
using Literature.Application.Exceptions;
using Literature.Domain.Entities;
using Literature.Domain.Repositories;
using Mapster;

namespace Literature.Application.Services
{
    internal sealed class AuthorService(IAuthorRepository authorRepository) : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));

        public async Task<IEnumerable<AuthorModel>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return authors.Adapt<IEnumerable<AuthorModel>>();
        }

        public async Task<AuthorModel> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return author is null ? throw new NotFoundException($"Author with Id {id} not found") : author.Adapt<AuthorModel>();
        }

        public async Task<IEnumerable<AuthorModel>> GetAuthorsByBookIdAsync(int bookId)
        {
            var authors = await authorRepository.GetByBookIdAsync(bookId);
            return authors.Adapt<IEnumerable<AuthorModel>>();
        }

        public async Task<AuthorModel> CreateAuthorAsync(CreateAuthorModel authorModel)
        {
            var author = authorModel.Adapt<Author>();
            await _authorRepository.AddAsync(author);

            return author.Adapt<AuthorModel>();
        }

        public async Task UpdateAuthorAsync(UpdateAuthorModel authorModel)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(authorModel.Id) ?? throw new NotFoundException($"Author with Id {authorModel.Id} not found");
            authorModel.Adapt(existingAuthor);

            await _authorRepository.UpdateAsync(existingAuthor);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            _ = await _authorRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Author with Id {id} not found");

            await _authorRepository.DeleteAsync(id);
        }
    }
}
