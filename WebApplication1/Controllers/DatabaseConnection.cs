using Npgsql;

namespace WebApplication1.Controllers
{
    public class DatabaseConnection
    {
        private String str = "Starttext";
        public String someText = "Text här";
        private String connectionString = "Server=127.0.0.1;Port=5432;User Id=an4283;Password=jmws6km4;Database=an4283;"; //jdbc:postgresql://pgserver.mau.se:5432/an4283
        public  async void connect() {
            try
            {
                someText = "1";
                using var con = new NpgsqlConnection(connectionString);
                someText = "2";
                con.Open();
                someText = "3";
                using var cmd = new NpgsqlCommand();
                someText = "4"; 
                cmd.Connection = con;
                someText = "5";
                cmd.CommandText = $"SELECT * from teacher";
                someText = "6";
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
                someText = "7";
                str = "";
                while (await reader.ReadAsync()) {
                    str += (reader["id"] + " " + reader.GetString(1)) + "  \n";
                }    
                con.Close();
            }
            catch (Npgsql.PostgresException)
            { someText = "postgresexeption";
            } catch (System.Exception)
            {} 
        
        }

        public DatabaseConnection(String str) {someText = str;}

        public String getStr() {
            return str;
        }
        public String getSomeText() {
            return someText;
        }
    

//        String connectionString = "Server=localhost;Port=5432;User Id=an4283;Password=jmws6km4;Database=an4283;";
    }
}