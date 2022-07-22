using Bussiness_logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Book_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
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
            if () { 
            
            }
            return Ok(book);
        }
    }
}
