using Bussiness_logic.Interfaces;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.RateDTOs;
using Domain.DTOs.ReviewDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Book_Web_Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IRewievService _rewievService;
        private readonly IRateService _rateService;
        private readonly IConfiguration _configuration;

        public BooksController(IBookService bookService, IConfiguration configuration, IRewievService rewievService, IRateService rateService)
        {
            _bookService = bookService;
            _configuration = configuration;
            _rewievService = rewievService;
            _rateService = rateService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetBooks(string order)
        {          
            if (order == null)
            {
                return BadRequest();
            }
            var result = await _bookService.GetBooks(order);
            return Ok(result);
        }       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
           
            var book = await _bookService.GetBook(id);
            if (book == null)
            {
                return BadRequest();
            }

            return Ok(book);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, string secret)
        {
            if (_configuration["secret"] != secret)
            {
                return BadRequest();
            }

            var isSuccess = await _bookService.Delete(id);
            if (isSuccess)
            {
                return Ok();

            }
            return BadRequest();
        }
        [HttpPost("save")]
        public async Task<IActionResult> Create([FromBody] CreateBookDTO bookDTO)
        {
            if (bookDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var bookId = await _bookService.Create(bookDTO);

            return Ok(bookId);
        }
        [HttpPut("{bookId}/review")]
        public async Task<IActionResult> SaveReview(int bookId, [FromBody] CreateRewievDTO rewievDTO)
        {
            if (rewievDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            rewievDTO.BookId = bookId;
            var rewievId = await _rewievService.Create(rewievDTO);

            if (rewievId == -1)
            {
                return BadRequest();
            }
            return Ok(rewievId);
        }
        [HttpPut("{bookId}/rate")]
        public async Task<IActionResult> SaveRate(int bookId, [FromBody] CreateRateDTO rateDTO)
        {        
            if (rateDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            rateDTO.BookId = bookId;
            var rateId=await _rateService.Create(rateDTO);
            if (rateId == -1)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
