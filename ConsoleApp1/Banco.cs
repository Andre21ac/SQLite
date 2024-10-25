using System;
using Microsoft.Data.Sqlite;

public class Banco
{
    string conectionStringMemory = "Data Source=memory:";
    static string conectionStringFile = @"Data Source=C:\Banco.db";

    public static void CriarTabela(string tituloTabela)
    {
        using var conection = new SqliteConnection(conectionStringFile);
        conection.Open();

        using var cmd = new SqliteCommand($"CREATE TABLE IF NOT EXISTS {tituloTabela} " + 
            "(ID INTEGER PRIMARY KEY, Name TEXT);", conection);
        cmd.ExecuteNonQuery();

        Console.WriteLine($"tabela: {tituloTabela} Criado com sucesso!");
    }

    public void ListarLivros()
    {
        using var conection = new SqliteConnection(conectionStringFile);
        conection.Open();
        
        using var readCmd = new SqliteCommand("SELECT * FROM Livros;", conection);
        using var reader = readCmd.ExecuteReader();

        Console.Clear();
        while (reader.Read())
        {
            Console.WriteLine($"ID: { reader["ID"] }");
            Console.WriteLine($"Título: {reader["Titulo"]}");
            Console.WriteLine($"Autor: {reader["Autor"]}");
            Console.WriteLine($"Ano de publicação: {reader["AnoDePublicacao"]}");
            Console.WriteLine($"Genêro: {reader["Genero"]}");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
        }
    }
    public void DeletarLivro(int id)
    {
        using var conection = new SqliteConnection(conectionStringFile);
        conection.Open();
        
        using var command = new SqliteCommand($"DELETE FROM Livros WHERE ID = @id;", conection);
        command.Parameters.AddWithValue("@id", id);

        command.ExecuteNonQuery();
    }

    public void AdicionarLivro(string titulo, string autor, int ano, string genero)
    {
        using var conection = new SqliteConnection(conectionStringFile);
        conection.Open();

        using var command = new SqliteCommand($"INSERT INTO Livros(Titulo, Autor, AnoDePublicacao, Genero) VALUES (@titulo, @autor, @ano, @genero)", conection);

        command.Parameters.AddWithValue("@titulo", titulo);
        command.Parameters.AddWithValue("@auotr", autor);
        command.Parameters.AddWithValue("@ano", ano);
        command.Parameters.AddWithValue("@genero", genero);

        command.ExecuteNonQuery();
    }
    

}