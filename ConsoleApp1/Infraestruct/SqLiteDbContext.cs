using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestruct
{
    public class SqLiteDbContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Dev\\Projetos\\C#\\SQLite\\Banco.db");
        }
    }
}
