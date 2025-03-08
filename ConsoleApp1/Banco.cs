using System;
using Microsoft.Data.Sqlite;

public class Banco
{
    string conectionStringMemory = "Data Source=memory:";
    static string conectionStringFile = @"Data Source=C:\Users\andre\RiderProjects\SQLite\Banco.db;";

    public void ListarLivros()
    {
        using var conection = new SqliteConnection(conectionStringFile);
        conection.Open();
        
        using var readCmd = new SqliteCommand("SELECT * FROM Livros;", conection);
        using var reader = readCmd.ExecuteReader();
        
        int i = 1;
        Console.Clear();
        while (reader.Read())
        {
            Console.WriteLine();
            Console.WriteLine($"Livro {i}");
            Console.WriteLine($"Título: {reader["Titulo"]}");
            Console.WriteLine($"Autor: {reader["Autor"]}");
            Console.WriteLine($"Ano de publicação: {reader["AnoDePublicacao"]}");
            Console.WriteLine($"Gênero: {reader["Genero"]}");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            i++;
        }
    }
    public void DeletarLivro(string titulo)
    {
        using var conection = new SqliteConnection(conectionStringFile);
        conection.Open();
        
        using var command = new SqliteCommand($"DELETE FROM Livros WHERE Titulo = @titulo;", conection);
        command.Parameters.AddWithValue("@titulo", titulo);

        command.ExecuteNonQuery();
    }

    public void AdicionarLivro(string titulo, string autor, int ano, string genero)
    {
        using var conection = new SqliteConnection(conectionStringFile);
        conection.Open();

        using var addCommand = new SqliteCommand("INSERT INTO Livros (Titulo, Autor, AnoDePublicacao, Genero) VALUES (@titulo, @autor, @ano, @genero);", conection);
        addCommand.Parameters.AddWithValue("@titulo", titulo);
        addCommand.Parameters.AddWithValue("@autor", autor);
        addCommand.Parameters.AddWithValue("@ano", ano);
        addCommand.Parameters.AddWithValue("@genero", genero);

        addCommand.ExecuteNonQuery();
    }

    public void PesquisarLivro(string titulo)
    {
        using var conection = new SqliteConnection(conectionStringFile);
        conection.Open();

        using var comando = new SqliteCommand($"SELECT * FROM Livros WHERE LOWER(Titulo) LIKE LOWER(@titulo);", conection);
        comando.Parameters.AddWithValue("@titulo", "%" + titulo + "%");
        
        using var reader = comando.ExecuteReader();

        int i = 0;
        while (reader.Read())
        {
            Console.Clear();
            Console.WriteLine($"Título: {reader["Titulo"]}");
            Console.WriteLine($"Autor: {reader["Autor"]}");
            Console.WriteLine($"Ano de publicação: {reader["AnoDePublicacao"]}");
            Console.WriteLine($"Gênero: {reader["Genero"]}");
            i++;
        }
        if (i == 0)
        {
            Console.Clear();
            Console.WriteLine("O título do livro não foi encontrado!");
        }
    }

}