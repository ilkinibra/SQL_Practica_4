using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Sql_Practica_1
{
    class Program
    {
        private static string connectionString =
           "Server=127.0.0.1;Database=Kurs;User Id=sa;Password=MyPass@word;";

        static async Task Main(string[] args)
        {
            //await GetByName();
            //await AddByName();
            await GetAllAsync();
        }

        public async static Task GetByName()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string command = "SELECT FullName FROM Students Where Id=4";
                using (SqlCommand com = new SqlCommand(command, connection))
                {
                    string name = (await com.ExecuteScalarAsync()).ToString();
                    Console.WriteLine(name);
                }
            }
        }

        public async static Task AddByName()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = "INSERT INTO Students VALUES('Elgun Qocayev')";
                using (SqlCommand sqlCommand = new SqlCommand(queryString, connection))
                {
                    int result = await sqlCommand.ExecuteNonQueryAsync();
                    if (result > 0)
                    {
                        Console.WriteLine("data is created");
                    }
                    else
                    {
                        Console.WriteLine("error");

                    }
                }
            }
        }

        public async static Task GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string command = "SELECT * FROM Students";
                using (SqlCommand Sqlcommand= new SqlCommand(command, connection))
                {
                    SqlDataReader reader= await Sqlcommand.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"FullName:{reader.GetValue(1)}");
                        }
                    }
                }
            }




        }

    }
}