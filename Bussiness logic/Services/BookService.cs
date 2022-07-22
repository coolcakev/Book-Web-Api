using AutoMapper;
using Bussiness_logic.Interfaces;
using DataAccess.Interfaces;
using Domain.DTOs;
using Domain.DTOs.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_logic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> GetBook(int id)
        {
            var book= await _bookRepository.GetByIdWithInclude(id,x=>x.Rewievs,x=>x.Ratings);
            if (book==null) {
                return null;
            }

            var bookDTO = _mapper.Map<BookDTO>(book);
            return bookDTO;
        }

        public async Task<IEnumerable<BookDTO>> GetBooks(string order)
        {
            var filteringModel = new SortingModel()
            {
                Name = order,
                SortOrder = SortOrder.Ask
            };
            var books = await _bookRepository.GetFiltered(filteringModel);
            var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
            return bookDTOs;
        }
    }
}
