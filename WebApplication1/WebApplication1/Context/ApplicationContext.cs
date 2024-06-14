using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System;

namespace WebApplication1.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Titles> TitlesEnumerable { get; set; }
        public DbSet<Items> ItemsEnumerable { get; set; }
        public DbSet<Characters> CharactersEnumerable { get; set; }
        public DbSet<Characters_Titles> CharacterTitlesEnumerable { get; set; }
        public DbSet<Backpack_Slots> BackpacksEnumerable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Characters>().HasData(
                new Characters { PK = 1, first_name = "Jan", last_name = "Kowal", current_weig = 10, max_weight = 50, money = 100 },
                new Characters { PK = 2, first_name = "Piotr", last_name = "Dzwon", current_weig = 5, max_weight = 45, money = 150 }
            );

            modelBuilder.Entity<Items>().HasData(
                new Items { Id = 1, Name = "Miecz", Weig = 5 },
                new Items { Id = 2, Name = "Tarcza", Weig = 7 }
            );

            modelBuilder.Entity<Titles>().HasData(
                new Titles { PK = 1, nam = "Wojownik" },
                new Titles { PK = 2, nam = "Mag" }
            );

            modelBuilder.Entity<Characters_Titles>().HasData(
                new Characters_Titles { FK_charact = 1, FK_title = 1, aquire_at = DateTime.Now },
                new Characters_Titles { FK_charact = 2, FK_title = 2, aquire_at = DateTime.Now }
            );

            modelBuilder.Entity<Backpack_Slots>().HasData(
                new Backpack_Slots { PK = 1, FK_item = 1, FK_character = 1 },
                new Backpack_Slots { PK = 2, FK_item = 2, FK_character = 2 }
            );
        }
    }
}