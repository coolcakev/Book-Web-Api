using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_logic.Interfaces
{
    public interface IFileService
    {
        Task CreateFile(IFormFile file, string path);
    }
}
