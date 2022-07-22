using Domain.DTOs.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_logic.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooks(string order);
        Task<BookDTO> GetBook(int id);
    }
}
