namespace ConsoleApp1.Entities
{
    public class Livro
    {
        public int ID { get; set;  }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int AnoDePublicacao { get; set; }
        public string Genero { get; set; } = string.Empty;
        public int Paginas { get; set; }
    }
}