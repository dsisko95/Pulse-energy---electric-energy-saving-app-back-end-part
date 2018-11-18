using DataLayer.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class UserRepository : IUserRepository
    {
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public User GetUserLogin(string username, string password)
        {
            User user = new User();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT u.Language, c.Name, ct.Location, u.Id, u.Currency  FROM Users u INNER JOIN Companies c ON u.Company_Id = c.Id INNER JOIN Cities ct ON ct.Id = c.City_Id  WHERE Username = @username AND Password = @password";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    user.Language = dataReader.GetString(0);
                    user.Company_Name = dataReader.GetString(1);
                    user.Company_Location = dataReader.GetString(2);
                    user.Id = dataReader.GetInt32(3);
                    user.Currency = dataReader.GetString(4);
                }
            }
            return user;
        }

        public User GetCheckUser(string username, string secQuestion)
        {
            User user = new User();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT Username FROM Users Where Username = @username AND SecurityQuestion = @secQuestion";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@secQuestion", secQuestion);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    user.Username = dataReader.GetString(0);
                }
            }
            return user;
        }

        public int UpdateUserPassword(User user)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Users SET Password = @password WHERE Username = @username";
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@username", user.Username);
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateUserLanguage(User user)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Users SET Language = @language WHERE Id = @Id";
                command.Parameters.AddWithValue("@language", user.Language);
                command.Parameters.AddWithValue("@Id", user.Id);
                return command.ExecuteNonQuery();
            }
        }
        public int UpdateUserCurrency(User user)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Users SET Currency = @currency WHERE Id = @Id";
                command.Parameters.AddWithValue("@currency", user.Currency);
                command.Parameters.AddWithValue("@Id", user.Id);
                return command.ExecuteNonQuery();
            }
        }
    }
}