using AutoMapper;
using Domain.DTOs.ReviewDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MappingProfile
{
    public class ReviewProfile:Profile
    {
        public ReviewProfile()
        {
            CreateMap<Rewiev, RewievDTO>();
            CreateMap<CreateRewievDTO, Rewiev>();
        }
    }
}
