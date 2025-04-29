using Literature.Application.Contracts.Services;
using Literature.Application.Dtos.Books;
using Literature.Application.Exceptions;
using Literature.Domain.Entities;
using Literature.Domain.Repositories;
using Mapster;

namespace Literature.Application.Services
{
    internal sealed class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));

        public async Task<IEnumerable<BookModel>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Adapt<IEnumerable<BookModel>>();
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return book is null ? throw new NotFoundException($"Author with Id {id} not found") : book.Adapt<BookModel>();
        }

        public async Task<BookModel> CreateBookAsync(CreateBookModel bookModel)
        {
            var book = bookModel.Adapt<Book>();
            await _bookRepository.AddAsync(book);

            return book.Adapt<BookModel>();
        }

        public async Task UpdateBookAsync(UpdateBookModel bookModel)
        {
            var existingBook = await _bookRepository.GetByIdAsync(bookModel.Id) ?? throw new NotFoundException($"Author with Id {bookModel.Id} not found");
            bookModel.Adapt(existingBook);

            await _bookRepository.UpdateAsync(existingBook);
        }

        public async Task DeleteBookAsync(int id)
        {
            _ = await _bookRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Author with Id {id} not found");

            await _bookRepository.DeleteAsync(id);
        }
    }
}
