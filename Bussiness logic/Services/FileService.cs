using Bussiness_logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Bussiness_logic.Services
{
    public class FileService : IFileService
    {
        public async Task CreateFile(IFormFile file, string path)
        {
            var fullPath=Path.Combine(path, file.FileName);
            using (var stream= new FileStream(fullPath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
