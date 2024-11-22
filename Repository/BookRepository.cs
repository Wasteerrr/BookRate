using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Book;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _context; 
        public BookRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> BookExist(int id)
        {
            return _context.Books.AnyAsync(s => s.Id == id);
        }

        public async Task<Book> CreateAsync(Book bookModel)
        {
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Book?> DeleteAsync(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if(bookModel == null)
            {
                return null;
            }

            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync(QueryObject query)
        {
            var books = _context.Books.Include(c => c.Comments).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.Titile))
            {
                books = books.Where(s => s.Title.Contains(query.Titile)); 
            }

            if(!string.IsNullOrWhiteSpace(query.Author))
            {
                books = books.Where(s => s.Author.Contains(query.Author));
            }

            return await books.ToListAsync();

        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Book?> UpdateAsync(int id, UpdateBookRequestDto bookDto)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if(existingBook == null)
            {
                return null;
            }

            existingBook.Key = bookDto.Key;
            existingBook.Title = bookDto.Title;
            existingBook.Author = bookDto.Author;
            existingBook.StarRating = bookDto.StarRating;
            existingBook.PublishYear = bookDto.PublishYear;

            await _context.SaveChangesAsync();
            return existingBook;
        }
    }
}