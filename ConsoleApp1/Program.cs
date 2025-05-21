using ConsoleApp1.Entities;
using ConsoleApp1.Infraestruct;
using ConsoleTables;

class Program
{
    static ConsoleKeyInfo opcao = new ConsoleKeyInfo();
    
    static void Main()
    {
        // Banco.Conect();

        while(opcao.Key != ConsoleKey.Escape)
        {
            Console.Clear();
            Console.WriteLine("Bem vindo(a)!");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Gerenciar Biblioteca");
            Console.WriteLine("ESC - Sair");

            opcao = Console.ReadKey();

            if (opcao.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Adicionar Livro");
                Console.WriteLine("2 - Listar Livros");
                Console.WriteLine("3 - Remover Livro");
                Console.WriteLine("4 - Voltar");

                opcao = Console.ReadKey();

                switch (opcao.Key)
                {
                    case ConsoleKey.D1:
                        AdicionarLivro();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D2:
                        ListarLivros();
                        Console.ReadKey();
                        break;
                
                    case ConsoleKey.D3:
                        RemoverLivro();
                        break;
                }
            }
        }

        static void ListarLivros()
        {
            Console.Clear();

            var dbContext = new SqLiteDbContext();
            var livros = dbContext.Livros.ToList();

            var table = new ConsoleTable("ID", "Título", "Autor", "Ano", "Gênero", "Páginas");

            foreach (var livro in livros)
            {
                table.AddRow(livro.ID, livro.Titulo, livro.Autor, livro.AnoDePublicacao, livro.Genero, livro.Paginas);
            }
            table.Write();
        }
    
        static void RemoverLivro()
        {
            Console.Clear();
            Console.WriteLine("Digite o id do livro que você deseja remover:");
            int id = int.Parse(Console.ReadLine());

            try{
                //banco.DeletarLivro(id);
                Console.Clear();
                Console.WriteLine("Livro removido com sucesso!");
                Thread.Sleep(2000);
            }
            catch(Exception e){
                Console.WriteLine($"Erro: {e.Message}");
            } 
        }

        static void AdicionarLivro()
        {
            Console.Clear();

            Console.WriteLine("Digite o Título do Livro:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o Nome do Autor do Livro:");
            string autor = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Publicação do Livro:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Gênero Livro:");
            string genero = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de Páginas do Livro:");
            int pags = int.Parse(Console.ReadLine());

            var dbContext = new SqLiteDbContext();

            var entity = new Livro
            {
                Titulo = titulo,
                Autor = autor,
                AnoDePublicacao = ano,
                Genero = genero,
                Paginas = pags
            };

            dbContext.Livros.Add(entity);
            dbContext.SaveChanges();

            Console.Clear();
            Console.WriteLine("Livro Adicionado com sucesso!");
        }
    }
}
