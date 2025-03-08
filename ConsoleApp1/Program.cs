using System;
using Microsoft.Data.Sqlite;

class Program
{
    static ConsoleKeyInfo opcao = new ConsoleKeyInfo();
    static Banco banco = new Banco();
    
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
                        break;

                    case ConsoleKey.D2:
                        banco.ListarLivros();
                        Console.ReadKey();
                        break;
                
                    case ConsoleKey.D3:
                        RemoverLivro();
                        break;
                }
            }
        }
    
        static void RemoverLivro()
        {
            Console.Clear();
            Console.WriteLine("Digite o titulo do livro que você deseja remover:");
            string titulo = Console.ReadLine();

            try{
                banco.DeletarLivro(titulo);
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

            try
            {
                banco.AdicionarLivro(titulo, autor, ano, genero, pags);
                Console.Clear();
                Console.WriteLine("Livro adicionado com sucesso!");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar livro: {ex.Message}");
            }
        }
    }
}
