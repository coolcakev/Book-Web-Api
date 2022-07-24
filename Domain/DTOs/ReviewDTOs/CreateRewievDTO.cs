using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.ReviewDTOs
{
    public class CreateRewievDTO
    {
        public int BookId { get; set; }
        public string Message { get; set; }
        [Required]
        public string Reviewer { get; set; }
    }
}
