using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IBookRepository _bookRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBMPService _bMPService;

        public CommentController(ICommentRepository commentRepo, IBookRepository bookRepo, UserManager<AppUser> userManager, IBMPService bmpService)
        {
            _commentRepo = commentRepo;
            _bookRepo = bookRepo;
            _userManager = userManager;
            _bMPService = bmpService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comments = await _commentRepo.GetAllAsync();
            
            var commentDto = comments.Select(s => s.ToCommentDto());
            
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepo.GetByIdAsync(id);

            if(comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        [Route("{title:alpha}")]
        public async Task<IActionResult> Create([FromRoute] string title, CreateCommentDto commentDto)
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
            
            var commentModel = commentDto.ToCommentFromCreate(book.Id);
            commentModel.AppUserId = appUser.Id;
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id}, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate());

            if(comment == null)
            {
                return NotFound("Komentarz nie znaleziony");
            }

            return Ok(comment.ToCommentDto());
        }

        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentModel = await _commentRepo.DeleteAsync(id);

            if(commentModel == null)
            {
                return NotFound("komentarz nie istnieje");
            }

            return Ok(commentModel);
        }

    }
}