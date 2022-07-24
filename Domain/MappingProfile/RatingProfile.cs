using AutoMapper;
using Domain.DTOs.RateDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MappingProfile
{
    public class RatingProfile:Profile
    {
        public RatingProfile()
        {
            CreateMap<CreateRateDTO, Rating>();
        }
    }
}
