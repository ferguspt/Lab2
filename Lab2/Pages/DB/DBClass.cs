using System.Data.SqlClient;

namespace Lab2.Pages.DB
{
    public class DBClass
    {

        // Connection object at the class level
        public static SqlConnection Lab2DBConnection = new SqlConnection();

        // Connection string
        // ";TrustServerCertificate=True"
        public static readonly String Lab2DBConnString = "Server=Localhost; Database=Lab2; Trusted_Connection=True";

        public static SqlDataReader UserReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = Lab2DBConnection;
            cmdProductRead.Connection.ConnectionString = Lab2DBConnString;
            cmdProductRead.CommandText = "SELECT * FROM User";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader EventReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = Lab2DBConnection;
            cmdProductRead.Connection.ConnectionString = Lab2DBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Event";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

    }
}
