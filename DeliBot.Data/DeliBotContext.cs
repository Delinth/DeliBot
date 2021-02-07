using DeliBot.Data.Models;
using DeliBot.Data.Models.GuessGame;
using Microsoft.EntityFrameworkCore;

namespace DeliBot.Data
{
    public class DeliBotContext : DbContext
    {
        public DeliBotContext(DbContextOptions<DeliBotContext> options) : base(options) {}
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<GuessOption> GuessOptions { get; set; }
        public DbSet<GuessPicture> GuessPictures { get; set; }
        public DbSet<GuessHint> GuessHints { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Guess Games

            modelBuilder.Entity<GuessOption>()
                .HasOne<Person>(go => go.Person);

            modelBuilder.Entity<GuessOption>()
                .HasMany<GuessPicture>(go => go.GuessPictures)
                .WithOne(gp => gp.GuessOption);

            modelBuilder.Entity<GuessOption>()
                .HasMany<GuessHint>(go => go.GuessHints)
                .WithOne(gh => gh.GuessOption);

            #endregion
        }
    }
}