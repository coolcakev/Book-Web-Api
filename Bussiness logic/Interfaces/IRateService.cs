using Domain.DTOs.RateDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_logic.Interfaces
{
    public interface IRateService
    {
        Task<int> Create(CreateRateDTO rateDTO);
    }
}
