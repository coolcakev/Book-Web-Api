using DataAccess.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RewievRepository : GenericRepository<Rewiev>, IRewievRepository
    {
        public RewievRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
