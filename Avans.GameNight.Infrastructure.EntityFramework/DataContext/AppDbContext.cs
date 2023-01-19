using Avans.GameNight.Core.Domain.Models;
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
        public DbSet<BoardGameNight> BoardGameNight { get; set; }

        public DbSet<BoardGameNightPlayer> BoardGameNightPlayer { get; set; }
        public DbSet<BoardGameNightBoardGame> BoardGameNightBoardGame { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Rating> Rating { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            //Set many to many relations keys
                     //
            modelBuilder.Entity<BoardGameNightPlayer>().HasKey(gn => new { gn.BoardGameNightNameNight, gn.PlayerMailAddress });

            modelBuilder.Entity<BoardGameNightBoardGame>().HasKey(gn2 => new { gn2.BoardGameNightNameNight, gn2.BoardGameNameGame });
            // modelBuilder.Entity().HasKey(gnp => new { gnp.GameNightId, gnp.PlayerId});           
            //modelBuilder.Entity().HasKey(gnc => new { gnc.GameNightId, gnc.ConsumableId });        }

        }
    }
}
