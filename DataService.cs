using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



namespace CCMS
{
    public class DataService
    {
        private string _connectionString;
        private static SqlConnection  Connection;

        static DataService()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
        }
        public DataTable GetDataWithoutParameter(string Command)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            DataTable result = new DataTable();
            using (SqlConnection Connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand DataCommand = Connection.CreateCommand())
                {
                    Connection.Open();
                    DataCommand.CommandType = CommandType.Text;
                    DataCommand.CommandText = Command;
                    SqlDataAdapter adapter = new SqlDataAdapter(DataCommand);

                    adapter.Fill(result);

                }
            }

            return result;
        }
        public DataTable GetDataWithParameters(SqlCommand command)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            DataTable result = new DataTable();
            using (SqlConnection Connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand DataCommand = command)
                {
                    Connection.Open();
                    DataCommand.CommandType = CommandType.Text;
                    DataCommand.Connection = Connection;
                    SqlDataAdapter adapter = new SqlDataAdapter(DataCommand);

                    adapter.Fill(result);

                }
            }

            return result;
        }

        public static int InsertIntoDatabase(string query, SqlParameter[] parameters)
        {
            int result = 0;
            
            using (SqlCommand command = new SqlCommand(query))
            {
                command.Connection = Connection;
                command.CommandType = CommandType.Text;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                Connection.Open();
                result = command.ExecuteNonQuery();
                Connection.Close();
            }


            return result;
        }


        public static string ReadDatabaseSingle(string query, SqlParameter[] parameter)
        {
            string result = String.Empty;

            using (SqlCommand command = new SqlCommand(query))
            {
                command.Connection = Connection;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@email",parameter[0].SqlValue);
                try
                {


                    //if (parameter != null)
                    //{
                    //    command.Parameters.AddRange(parameter);
                    //}
                    Connection.Open();
                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch
                {
                    Console.WriteLine("Some exception Occured");
                }
                finally
                {

                    Connection.Close();
                }
            }

            return result;
        }

        public static DataTable ReadDB(string query, SqlParameter[] parameter)
        {
            DataTable result = new DataTable();

            using (SqlCommand command = new SqlCommand(query))
            {
                command.Connection = Connection;
                command.CommandType = CommandType.Text;

                if (parameter != null)
                {
                    command.Parameters.AddRange(parameter);
                }
                Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(result);
                Connection.Close();

            }

            return result;
        }

       
    }
}