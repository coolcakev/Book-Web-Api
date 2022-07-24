using AutoMapper;
using Bussiness_logic.Interfaces;
using DataAccess.Interfaces;
using Domain.DTOs.RateDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_logic.Services
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public RateService(IRateRepository rateRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<int> Create(CreateRateDTO rateDTO)
        {
            var book = await _bookRepository.GetById(rateDTO.BookId);
            if (book == null)
            {
                return -1;
            }

            var rating = _mapper.Map<Rating>(rateDTO);
            await _rateRepository.Insert(rating);
            await _rateRepository.Save();
            return rating.Id;
        }
    }
}
