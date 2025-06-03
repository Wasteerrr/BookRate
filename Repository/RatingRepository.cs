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

        public async Task<Rating> DeleteAsync(int id)
        {        
            var ratingModel = await _context.Ratings.FirstOrDefaultAsync(x => x.Id == id);

            if(ratingModel == null)
            {
                return null;
            }

            _context.Ratings.Remove(ratingModel);
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

        public async Task<Rating> UpdateAsync(int id, Rating ratingModel)
        {
            var existingRating = await _context.Ratings.FindAsync(id);

            if(existingRating == null)
            {
                return null;
            }

            existingRating.Score = ratingModel.Score;

            await _context.SaveChangesAsync();

            return existingRating;

        }
    }
}