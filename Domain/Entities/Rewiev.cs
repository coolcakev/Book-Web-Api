using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Rewiev
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Reviewer { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
