using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {   
        public int Id { get ; set; }
        public string Title { get; set; }
        public string Cover { get; set; }

        public string Content { get; set; }
        public string Author { get; set; }

        public string Gener { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Rewiev> Rewievs { get; set; }
    }
}
