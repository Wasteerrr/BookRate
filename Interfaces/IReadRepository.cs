using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IReadRepository
    {
        Task<List<Book>> GetUserRead(AppUser user);
        Task<Read> CreateAsync(Read read);
        Task<Read> DeleteRead(AppUser appUser, string title);
    }
}