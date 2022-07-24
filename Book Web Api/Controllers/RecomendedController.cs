using Bussiness_logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Book_Web_Api.Controllers
{
    [Route("api/recomended")]
    [ApiController]
    public class RecomendedController : ControllerBase
    {
        private readonly IBookService _bookService;

        public RecomendedController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetRecomendedBooks(string genre)
        {
            var result = await _bookService.GetRecomendedBooks(genre);
            return Ok(result);
        }
    }
}
