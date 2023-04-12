using Npgsql;

namespace WebApplication1.Controllers
{
    public class DatabaseConnection
    {
        private String str = "Starttext";
        public String someText = "Text här";
        //private String connectionString = "Server=pgserver.mau.se;Port=5432;User Id=an4283;Password=jmws6km4;Database=an4283;"; //jdbc:postgresql://pgserver.mau.se:5432/an4283
        //private String connectionString = "Host=jdbc:postgresql://pgserver.mau.se;Username=an4283;Password=jmws6km4;Database=an4283";
        public  async void connect() {
            try
            {
                var connectionString = "Host=jdbc:postgresql://pgserver.mau.se;Username=an4283;Password=jmws6km4;Database=an4283";
                
                var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
                someText = "1";
                var dataSource = dataSourceBuilder.Build();
                someText = "2";
                var conn = await dataSource.OpenConnectionAsync();
                someText = "3";
                await using (var cm = new NpgsqlCommand("SELECT CURRENT_DATE", conn)) {
                someText = "4";
                await using (var reader = await cm.ExecuteReaderAsync())
                {
                    someText = "5";
                    while (await reader.ReadAsync())
                    {
                        someText = reader.GetString(0);
                    }
                }
                }

                // someText = "1dvsdf";
                // await using var dataSource = NpgsqlDataSource.Create(connectionString);
                // someText = "2hsafjh";
                // await using var command = dataSource.CreateCommand("SELECT CURRENT_DATE");
                // someText = "3dgfsd";
                // await using var reader = await command.ExecuteReaderAsync();
                // someText = "4"; 

                // while (await reader.ReadAsync())
                // {
                //     someText = reader.GetString(0); 
                // }   
            }
            catch (Npgsql.PostgresException)
            { someText = "postgresexeption";
            } catch (System.Exception e)
            { someText += e.Message; } 
            /*try
            {
                someText = "1dvsdf";
                using var con = new NpgsqlConnection(connectionString);
                someText = "2hsafjh";
                con.Open();
                someText = "3";
                using var cmd = new NpgsqlCommand();
                someText = "4"; 
                cmd.Connection = con;
                someText = "5";
                cmd.CommandText = $"SELECT CURRENT_DATE";
                someText = "6m,s";
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
                someText = reader.GetString(0);
                str = "";
                // while (await reader.ReadAsync()) {
                //     str += (reader["book_id"] + " " + reader.GetString(1) + "  " + reader.GetString(1) + "  \n");
                // }    
                con.Close();
            }
            catch (Npgsql.PostgresException)
            { someText = "postgresexeption";
            } catch (System.Exception)
            {} */
        
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