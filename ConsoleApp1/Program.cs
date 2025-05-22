using ConsoleApp1.Entities;
using ConsoleApp1.Infraestruct;
using ConsoleTables;
using System.Globalization;

class Program
{
    static ConsoleKeyInfo opcao = new ConsoleKeyInfo();
    
    static void Main()
    {
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
                        break;

                    case ConsoleKey.D2:
                        ListarLivros();
                        Console.WriteLine("Digite qualquer tecla para voltar");
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

            var table = new ConsoleTable("Livro", "Título", "Autor", "Ano", "Gênero", "Páginas");

            int i = 1;

            foreach (var livro in livros)
            {
                table.AddRow(i, livro.Titulo, livro.Autor, livro.AnoDePublicacao, livro.Genero, livro.Paginas);
                i++;
            }
            table.Write();
        }
    
        static void RemoverLivro()
        {
            Console.Clear();
            ListarLivros();
            Console.WriteLine("Digite o título do livro que você deseja remover:");
            string titulo = Console.ReadLine();
                                    
            while(titulo == "")
            {
                Console.WriteLine("O título do livro não pode ser vazio. Digite novamente:");
                titulo = Console.ReadLine();
            }

                try
                {
                    var dbContext = new SqLiteDbContext();

                    var livro = dbContext.Livros.FirstOrDefault(l => l.Titulo == titulo);

                    if (livro != null)
                    {
                        dbContext.Livros.Remove(livro);
                        dbContext.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("Livro removido com sucesso!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("O título do livro que você digitou não foi encontrado!");
                        Thread.Sleep(2000);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                }
        }

        static void AdicionarLivro()
        {
            Console.Clear();

            Console.WriteLine("Digite o Título do Livro:");
            string titulo = Console.ReadLine();
            while(titulo == "")
            {
                Console.Clear();
                Console.WriteLine("O titulo não pode ser vazio!");
                titulo = Console.ReadLine();
            }
      
            Console.WriteLine("Digite o Nome do Autor do Livro:");
            string autor = Console.ReadLine();
            while (autor == "")
            {
                Console.Clear();
                Console.WriteLine("O nome do autor não pode ser vazio!");
                autor = Console.ReadLine();
            }

            Console.WriteLine("Digite o ano de publicação do Livro:");
            string ano = Console.ReadLine();

            bool converterAno = int.TryParse(ano, out int anoconvertido);

            while (converterAno != true || anoconvertido < 0)
            {
                Console.Clear();
                Console.WriteLine("O ano precisar ser um número inteiro e maior que zero!");
                string anoString = Console.ReadLine();

                bool convertAno = int.TryParse(anoString, out anoconvertido);

                if(convertAno == true)
                {
                    converterAno = true;
                }
            }

            Console.WriteLine("Digite o Gênero Livro:");
            string genero = Console.ReadLine();

            while(genero == "")
            {
                Console.Clear();
                Console.WriteLine("O gênero não pode ser vazio!");
                genero = Console.ReadLine();
            }

            Console.WriteLine("Digite a quantidade de Páginas do Livro:");
            string pags = Console.ReadLine();

            bool converterPags = int.TryParse(pags, out int pagconvertida);

            while (converterPags != true || pagconvertida < 0)
            {
                Console.Clear();
                Console.WriteLine("A quntidade de páginas precisa ser um número inteiro e maior que zero!");
                string pagString = Console.ReadLine();

                bool convertPag = int.TryParse(pagString, out pagconvertida);

                if (converterPags == true)
                {
                    converterPags = true;
                }
            }

            var dbContext = new SqLiteDbContext();

            var entity = new Livro
            {
                Titulo = titulo,
                Autor = autor,
                AnoDePublicacao = anoconvertido,
                Genero = genero,
                Paginas = pagconvertida
            };

            dbContext.Livros.Add(entity);
            dbContext.SaveChanges();

            Console.Clear();
            Console.WriteLine("Livro Adicionado com sucesso!");
            Thread.Sleep(2000);
        }
    }
}
