using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.BookDTOs
{
    public  class CreateBookDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Cover { get; set; } 
        public string Content { get; set; }
        [Required]
        public string Gener { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
