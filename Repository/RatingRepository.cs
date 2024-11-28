using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDBContext _context;        
        public RatingRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Rating> CreateAsync(Rating ratingModel)
        {
            await _context.Ratings.AddAsync(ratingModel);
            await _context.SaveChangesAsync();
            return ratingModel;
        }

        public async Task<List<Rating>> GetAllAsync(RatingQueryObject queryObject)
        {
            var ratings = _context.Ratings.Include(a => a.AppUser).AsQueryable();
            if(!string.IsNullOrWhiteSpace(queryObject.Title))
            {
                ratings = ratings.Where(s => s.Book.Title == queryObject.Title);
            };
            if(queryObject.IsDescending == true)
            {
                ratings = ratings.OrderByDescending(c => c.Score);
            }
            return await ratings.ToListAsync();
        }

        public async Task<Rating?> GetByIdAsync(int id)
        {
            return await _context.Ratings.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}