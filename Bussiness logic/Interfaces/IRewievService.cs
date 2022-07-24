using Domain.DTOs.ReviewDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_logic.Interfaces
{
    public interface IRewievService
    {
        Task<int> Create(CreateRewievDTO rewievDTO);
    }
}
