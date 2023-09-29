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

        public static int SecureLogin(string Username, string Password)
        {
            string loginQuery =
                "SELECT COUNT(*) FROM Credentials where Username = @Username and Password = @Password";

            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = Lab2DBConnection;
            cmdLogin.Connection.ConnectionString = Lab2DBConnString;

            cmdLogin.CommandText = loginQuery;
            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Parameters.AddWithValue("@Password", Password);

            cmdLogin.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            int rowCount = (int)cmdLogin.ExecuteScalar();

            return rowCount;
        }

    }
}
