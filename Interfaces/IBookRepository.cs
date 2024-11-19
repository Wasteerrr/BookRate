using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Models;

namespace api.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book bookModel);
        Task<Book?> UpdateAsync(int id, UpdateBookRequestDto bookDto);
        Task<Book?> DeleteAsync(int id);
    }
}