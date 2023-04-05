using Npgsql;

namespace WebApplication1.Controllers
{
    public class DatabaseConnection
    {
        String connectionString = "Server=jdbc:postgresql://pgserver.mau.se;Port=5432;User Id=an4283;Password=jmws6km4;Database=an4283;";
        public async void connect() {
            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            using var cmd = new NpgsqlCommand();

            cmd.Connection = con;

            cmd.CommandText = $"SELECT * from teacher";

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                Console.WriteLine(reader["id"] + " " + reader.GetString(1));
            }    
            con.Close();
        }

        public DatabaseConnection() {}
    

//        String connectionString = "Server=localhost;Port=5432;User Id=an4283;Password=jmws6km4;Database=an4283;";
    }
}