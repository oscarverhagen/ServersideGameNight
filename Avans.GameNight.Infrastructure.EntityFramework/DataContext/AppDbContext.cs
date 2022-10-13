using Avans.GameNight.App.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Infrastructure.EntityFramework.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BoardGame> BoardGame { get; set; }
        public DbSet<Avans.GameNight.App.Models.BoardGameNight> BoardGameNight { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Rating> Rating { get; set; }

     
    }
}
