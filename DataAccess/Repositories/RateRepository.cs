using DataAccess.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RateRepository : GenericRepository<Rating>, IRateRepository
    {
        public RateRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
