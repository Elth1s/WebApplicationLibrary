using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Урок_2.Data.Models;
using WebApplication_Урок_2.Data.Services;
using WebApplication_Урок_2.Data.ViewModels;

namespace WebApplication_Урок_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublishersService _publishersService;
        private readonly ILogger<PublishersController> _logger;
        public PublishersController(PublishersService publishersService, ILogger<PublishersController> logger)
        {
            _logger = logger;
            _publishersService = publishersService;
        }

        [HttpGet("get-publishers")]
        public IActionResult GetPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                _logger.LogInformation($"Test log: sortBy: {sortBy}");
                var publishers = _publishersService.GetPublishers(sortBy, searchString, pageNumber);
                return Ok(publishers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _publishersService.GetPublisherById(id);
            if (publisher != null)
                return Ok(publisher);
            else
                return NotFound();
        }
        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _pablosherData = _publishersService.GetPublisherData(id);
            if (_pablosherData != null)
            {
                return Ok(_pablosherData);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            var newPublisher = _publishersService.AddPublisher(publisher);
            return Created(nameof(AddPublisher), newPublisher);
        }
        [HttpDelete("delete-publisher/{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _publishersService.DeletePublisher(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-publisher/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] PublisherVM publisher)
        {
            var updatedPublisher = _publishersService.UpdatePublisherById(id, publisher);
            return Ok(updatedPublisher);
        }
    }
}
