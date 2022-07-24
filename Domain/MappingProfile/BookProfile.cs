using AutoMapper;
using Domain.DTOs.BookDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MappingProfile
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDTO, Book>();

            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.ReviewsNumber, opt => opt.MapFrom(src => src.Rewievs.Count))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings.Count != 0 ? src.Ratings.Average(x => x.Score) : 0));

            CreateMap<Book, SingleBookDTO>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings.Count != 0 ? src.Ratings.Average(x => x.Score) : 0));

        }
    }
}
