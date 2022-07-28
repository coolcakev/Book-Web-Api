using Bussiness_logic.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Book_Web_Api.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            if (file == null||file.Length==0)
            {
                return BadRequest();
            }
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "photos");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            await _fileService.CreateFile(file, path);
            return Ok();
        }
    }
}
