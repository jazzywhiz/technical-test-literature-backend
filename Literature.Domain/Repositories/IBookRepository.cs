﻿using Literature.Domain.Entities;

namespace Literature.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(int id);

        Task AddAsync(Book book);

        Task UpdateAsync(Book book);

        Task DeleteAsync(int id);
    }
}
