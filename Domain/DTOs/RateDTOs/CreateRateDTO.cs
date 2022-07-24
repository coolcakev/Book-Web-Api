using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.RateDTOs
{
    public  class CreateRateDTO
    {
        public int BookId { get; set; }
        [Required]
        [Range(1,5)]
        public int Score { get; set; }
    }
}
