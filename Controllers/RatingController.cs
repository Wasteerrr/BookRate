using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Rating;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRatingRepository _ratingRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IBMPService _bMPService;
        public RatingController(UserManager<AppUser> userManager, IRatingRepository ratingRepo, IBookRepository bookRepo, IBMPService bMPService)
        {
            _ratingRepo = ratingRepo;
            _bookRepo = bookRepo;
            _bMPService = bMPService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] RatingQueryObject queryObject)
         {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ratings = await _ratingRepo.GetAllAsync(queryObject);
            
            var ratingDto = ratings.Select(s => s.ToRatingDto());
            
            return Ok(ratingDto);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rating = await _ratingRepo.GetByIdAsync(id);

            if(rating == null)
            {
                return NotFound();
            }

            return Ok(rating.ToRatingDto()); 
        }

        [HttpPost]
        [Route("{title}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] string title, CreateRatingDto ratingDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _bookRepo.GetByTitleAsync(title);

            if(book == null)
            {
                book = await _bMPService.FindBookByTitleAsync(title);
                if(book == null)
                {
                    return BadRequest("Książka o tym tytule nie istnieje");
                }
                else
                {
                    await _bookRepo.CreateAsync(book);
                }
            }
            
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var ratingModel = ratingDto.ToRatingFromCreate(book.Id);
            ratingModel.AppUserId = appUser.Id;
            await _ratingRepo.CreateAsync(ratingModel);
            return CreatedAtAction(nameof(GetById), new { id = ratingModel.Id }, ratingModel.ToRatingDto());
          
        }

    }
}