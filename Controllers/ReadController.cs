using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/read")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBookRepository _bookRepo;
        private readonly IReadRepository _readRepo;
        public ReadController(UserManager<AppUser> userManager, IBookRepository bookRepo, IReadRepository readRepo)
        {
            _userManager = userManager;
            _bookRepo = bookRepo;
            _readRepo = readRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserRead()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userRead = await _readRepo.GetUserRead(appUser);
            return Ok(userRead);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRead(string key)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var book = await _bookRepo.GetByKeyAsync(key);

            if(book == null) return BadRequest("Książka nie znaleziona");

            var userRead = await _readRepo.GetUserRead(appUser);

            if(userRead.Any(e => e.Key.ToLower() == key.ToLower())) return BadRequest("Nie możesz dodać tej samej książki drugi raz");

            var readModel = new Read
            {
                BookId = book.Id,
                AppUserId = appUser.Id
            };

            await _readRepo.CreateAsync(readModel);
            
            if(readModel == null)
            {
                return StatusCode(500, "Nie udało się utworzyć");
            }
            else
            {
                return Created();
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteRead(string key)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userRead = await _readRepo.GetUserRead(appUser);

            var filteredBook = userRead.Where(s => s.Key.ToLower() == key.ToLower()).ToList();

            if (filteredBook.Count() == 1)
            {
                await _readRepo.DeleteRead(appUser, key);
            }
            else
            {
                return BadRequest("Brak książki o tym kluczu w przeczytanych");
            }

            return Ok();
        }
    }
}