using AutoMapper;
using Bussiness_logic.Interfaces;
using DataAccess.Interfaces;
using Domain.DTOs.ReviewDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_logic.Services
{
    public class RewievService : IRewievService
    {
        private readonly IRewievRepository _rewievRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public RewievService(IRewievRepository rewievRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _rewievRepository = rewievRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<int> Create(CreateRewievDTO rewievDTO)
        {
            var book = await _bookRepository.GetById(rewievDTO.BookId);
            if (book == null)
            {
                return -1;
            }

            var rewiev = _mapper.Map<Rewiev>(rewievDTO);
            await _rewievRepository.Insert(rewiev);
            await _rewievRepository.Save();
            return rewiev.Id;
        }
    }
}
