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

        public async Task<bool> BookExist(int id)
        {
            return await _context.Books.AnyAsync(s => s.Id == id);
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
            var books = _context.Books.Include(c => c.Comments).Include(b => b.Ratings).ThenInclude(a => a.AppUser).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.Title))
            {
                books = books.Where(s => s.Title.Contains(query.Title)); 
            }

            if(!string.IsNullOrWhiteSpace(query.Author))
            {
                books = books.Where(s => s.Author.Contains(query.Author));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    books = query.IsDescending ? books.OrderByDescending(s => s.Title) : books.OrderBy(s => s.Title);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;


            
            return await books.Skip(skipNumber).Take(query.PageSize).ToListAsync();

        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Book?> GetByTitleAsync(string title)
        {
            return await _context.Books.FirstOrDefaultAsync(s => s.Title == title);
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
            existingBook.PublishYear = bookDto.PublishYear;

            await _context.SaveChangesAsync();
            return existingBook;
        }
    }
}