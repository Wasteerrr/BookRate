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
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _context; 
        public BookRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<Book>> GetAllAsync()
        {
            return _context.Books.ToListAsync();
        }
    }
}