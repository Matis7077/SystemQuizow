using Microsoft.EntityFrameworkCore;
using QuizCore.Modele;

namespace QuizCore.Dane
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Quiz> Quizy { get; set; }
        public DbSet<Pytanie> Pytania { get; set; }
        public DbSet<Odpowiedz> Odpowiedzi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=QuizyBaza;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Pytania)
                .WithOne(p => p.Quiz)
                .HasForeignKey(p => p.QuizId);

            modelBuilder.Entity<Pytanie>()
                .HasMany(p => p.Odpowiedzi)
                .WithOne(o => o.Pytanie)
                .HasForeignKey(o => o.PytanieId);
        }
    }
}