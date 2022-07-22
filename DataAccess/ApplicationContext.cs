using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        public DbSet<Book> Books { get; set; }   
        public DbSet<Rating> Ratings { get; set; }   
        public DbSet<Rewiev> Rewievs { get; set; }   

    }
}
