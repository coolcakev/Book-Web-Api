using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class SortingModel: PagingingModel
    {
        public string Name { get; set; }
        public SortOrder SortOrder { get; set; }
    }
}
