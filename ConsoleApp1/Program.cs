using System;
using Microsoft.Data.Sqlite;

class Program
{
    static ConsoleKeyInfo opcao = new ConsoleKeyInfo();
    static Banco banco = new Banco();
    static void Main()
    {
        Banco.Conect();

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

                opcao = Console.ReadKey();

                switch (opcao.Key)
                {
                    case ConsoleKey.D1:
                        // AdicionarLivros();
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
            Console.WriteLine("Digite o id do livro que você deseja remover:");
            int id = int.Parse(Console.ReadLine());

            banco.DeletarLivro(id);
        }
    }
}
