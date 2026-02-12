using APIConsumidor.Models;
using Microsoft.Data.Sqlite;
using System.Text.Json;

public class Program
{
    static async Task<List<Product>> GetProdutosDados()
    {
        using (HttpClient Client = new HttpClient())
        {
            try
            {
                var Dados = await Client.GetAsync("https://simple-grocery-store-api.click/products");
                var JsonDados = await Dados.Content.ReadAsStringAsync();
                List<Product> product = JsonSerializer.Deserialize<List<Product>>(JsonDados);
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }

    private static async Task Main(string[] args)
    {
        string ConnectionString = "Data Source=C:\\Users\\erick\\source\\repos\\SuperVendas\\SuperVendas\\DbContextFiles\\banco.db";
        using (var Connection = new SqliteConnection(ConnectionString))
        {
            Connection.Open();
            var insert = Connection.CreateCommand();
            insert.CommandText =
                @"
                    INSERT INTO Products (Category, Name, InStock)
                    VALUES ($category, $name, $inStock);
                ";
            int contador = 0;

            foreach (var item in await GetProdutosDados())
            {
                insert.Parameters.Clear();
                
                insert.Parameters.AddWithValue("$category", item.category);
                insert.Parameters.AddWithValue("$name", item.name);
                insert.Parameters.AddWithValue("$inStock", item.inStock);
                insert.ExecuteNonQuery();
                Console.WriteLine($"Adicionado {contador++} dados.");
            }
            
        }
    }
}