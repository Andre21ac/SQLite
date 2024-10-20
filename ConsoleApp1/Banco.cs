using System;
using Microsoft.Data.Sqlite;

public class Banco
{
    string conectionStringMemory = "Data Source=memory:";
    static string conectionStringFile = @"Data Source=C:\Users\halan\OneDrive\Área de Trabalho\csharpSQLite\Banco.db";

    public static void Conect()
    {
        using var conection = new SqliteConnection(conectionStringFile);
        conection.Open();
    }

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
            Console.WriteLine($"ID: {reader["ID"]}");
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
        
        using var readCmd = new SqliteCommand($"DELETE FROM Livros WHERE ID = {id};", conection);
        using var reader = readCmd.ExecuteReader();
    }

}