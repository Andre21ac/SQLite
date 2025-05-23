using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestruct
{
    public class SqLiteDbContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppContext.BaseDirectory, "Banco.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
