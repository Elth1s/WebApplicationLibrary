using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Урок_2.Data.Services;
using WebApplication_Урок_2.Data.ViewModels;

namespace WebApplication_Урок_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet("get-authors")]
        public IActionResult GetAuthors()
        {
            var authors = _authorsService.GetAuthors();
            return Ok(authors);
        }
        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorsService.GetAuthorById(id);
            if (author != null)
                return Ok(author);
            else
                return NotFound();
        }
        [HttpGet("get-author-with-books/{id}")]
        public IActionResult GetAuthorsWithBooks(int id)
        {
            var _author = _authorsService.GetAuthorWithBooks(id);

            if (_author != null)
            {
                return Ok(_author);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("add-author")]
        public IActionResult AddPublisher([FromBody] AuthorVM author)
        {
            var newAuthor = _authorsService.AddAuthor(author);
            return Created(nameof(AddPublisher), newAuthor);
        }
        [HttpDelete("delete-author/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                _authorsService.DeleteAuthor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-author/{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] AuthorVM author)
        {
            var updatedAuthor = _authorsService.UpdateAuthorById(id, author);
            return Ok(updatedAuthor);
        }
    }
}
