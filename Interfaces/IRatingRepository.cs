using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAllAsync(Helpers.RatingQueryObject queryObject);
        Task<Rating?> GetByIdAsync(int id);
        Task<Rating> CreateAsync(Rating ratingModel);
    }
}