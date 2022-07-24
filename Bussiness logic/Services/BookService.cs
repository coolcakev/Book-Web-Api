using AutoMapper;
using Bussiness_logic.Interfaces;
using DataAccess.Interfaces;
using Domain.DTOs;
using Domain.DTOs.BookDTOs;
using Domain.Entities;
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

        public async Task<int> Create(CreateBookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            if (bookDTO.Id.HasValue && bookDTO.Id != 0)
            {
                _bookRepository.Update(book);
                await _bookRepository.Save();
                return bookDTO.Id.Value;
            }
            await _bookRepository.Insert(book);
            await _bookRepository.Save();
            return book.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var book = await _bookRepository.GetById(id);
            if (book == null)
            {
                return false;
            }

            _bookRepository.Delete(book);
            await _bookRepository.Save();
            return true;
        }

        public async Task<SingleBookDTO> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdWithInclude(id, x => x.Rewievs, x => x.Ratings) as Book;

            if (book == null)
            {
                return null;
            }

            var bookDTO = _mapper.Map<SingleBookDTO>(book);
            return bookDTO;
        }

        public async Task<IEnumerable<BookDTO>> GetBooks(string order)
        {
            var filteringModel = new SortingModel()
            {
                Name = order,
                SortOrder = SortOrder.Desc
            };
            var books = await _bookRepository.GetFiltered(filteringModel, null, x => x.Rewievs, x => x.Ratings);
            var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
            return bookDTOs;
        }

        public async Task<IEnumerable<BookDTO>> GetRecomendedBooks(string genre)
        {
            genre ??= "";
            var filteringModel = new SortingModel()
            {
                Name = "Ratings.Count() != 0 ? Ratings.Average(Score) : 0",
                SortOrder = SortOrder.Desc,
                Page = 0,
                Count = 10,
            };

            var books = await _bookRepository.GetFiltered(filteringModel,
                x => x.Rewievs.Count > 10 && x.Gener.Contains(genre),
                x => x.Rewievs, x => x.Ratings);

            var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
            return bookDTOs;
        }
    }
}
