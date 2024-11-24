using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReadRepository : IReadRepository
    {
        private readonly ApplicationDBContext _context;
        public ReadRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Read> CreateAsync(Read read)
        {
            await _context.Reads.AddAsync(read);
            await _context.SaveChangesAsync();
            return read;
        }

        public async Task<Read> DeleteRead(AppUser appUser, string key)
        {
            var readModel = await _context.Reads.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.Book.Key.ToLower()  == key.ToLower());

            if(readModel == null)
            {
                return null;
            }

            _context.Reads.Remove(readModel);
            await _context.SaveChangesAsync();
            return readModel;
        }

        public async Task<List<Book>> GetUserRead(AppUser user)
        {
            return await _context.Reads.Where(u => u.AppUserId == user.Id)
            .Select(book => new Book
            {
                Id = book.BookId,
                Key = book.Book.Key,
                Title = book.Book.Title,
                Author = book.Book.Author,
                PublishYear = book.Book.PublishYear,
                Cover = book.Book.Cover,
                Description = book.Book.Description,
                SubjectPlace = book.Book.SubjectPlace,
                SubjectTimes = book.Book.SubjectTimes,
                Subjects = book.Book.Subjects


            }).ToListAsync();
        }
    }
}