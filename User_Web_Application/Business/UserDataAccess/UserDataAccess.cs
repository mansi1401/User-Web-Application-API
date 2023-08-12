using Dapper;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using User_Web_Application.Business.UserDataAccess.Interfaces;
using User_Web_Application.Domain.Models;
using User_Web_Application.Infrastructure.Data;

namespace User_Web_Application.Business.UserDataAccess
{
    /// <summary>
    /// Data access layer for user-related operations.
    /// </summary>
    public class UserDataAccess : IUserDataAccess
    {
        private readonly DbContext _dbContext;

        public UserDataAccess(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Helper method to get hashed password using SHA256 algorithm
        private string GetHashedPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // Get all users from the database
        public async Task<List<Users>> GetAllUsers()
        {
            using (IDbConnection dbConnection = _dbContext.CreateConnection())
            {
                dbConnection.Open();
                string sQuery = "Select * from Users";
                List<Users> users = (await dbConnection.QueryAsync<Users>(sQuery)).ToList();
                dbConnection.Close();
                return users;
            }
        }

        // Get a user by email from the database
        public async Task<Users> GetUserByEmail(string email)
        {
            using (IDbConnection dbConnection = _dbContext.CreateConnection())
            {
                dbConnection.Open();
                string sQuery = "Select * from Users Where Email = @Email";
                Users users = await dbConnection.QueryFirstOrDefaultAsync<Users>(sQuery, new { Email = email });
                dbConnection.Close();
                return users;
            }
        }

        // Create a new user in the database
        public async Task<bool> CreateUser(Users users)
        {
            // Generate the hashed password using SHA256 algorithm
            string hashedPassword = GetHashedPassword(users.Password_Hash);
            users.Password_Hash = hashedPassword;

            using (IDbConnection dbConnection = _dbContext.CreateConnection())
            {
                dbConnection.Open();
                string sQuery = "INSERT INTO Users (Name, Email, Password_Hash) VALUES (@Name, @Email, @Password_Hash)";
                int count = await dbConnection.ExecuteAsync(sQuery, users);
                dbConnection.Close();
                return count > 0;
            }
        }

        // Get a user by ID from the database
        public async Task<Users> GetUserById(int user_Id)
        {
            using (IDbConnection dbConnection = _dbContext.CreateConnection())
            {
                dbConnection.Open();
                string sQuery = "Select * from Users Where User_Id = @User_Id";
                Users users = await dbConnection.QueryFirstOrDefaultAsync<Users>(sQuery, new { User_Id = user_Id });
                dbConnection.Close();
                return users;
            }
        }

        // Update a user in the database
        public async Task<bool> UpdateUser(Users users)
        {
            using (IDbConnection dbConnection = _dbContext.CreateConnection())
            {
                dbConnection.Open();
                string sQuery = "UPDATE Users SET Name = @Name, Email = @Email WHERE User_Id = @User_Id";
                int count = await dbConnection.ExecuteAsync(sQuery, users);
                dbConnection.Close();
                return count > 0;
            }
        }

        // Delete a user from the database
        public async Task<bool> DeleteUser(int user_Id)
        {
            using (IDbConnection dbConnection = _dbContext.CreateConnection())
            {
                dbConnection.Open();
                string sQuery = "Delete from Users Where User_Id = @User_Id";
                int count = await dbConnection.ExecuteAsync(sQuery, new { User_Id = user_Id });
                dbConnection.Close();
                return count > 0;
            }
        }
    }
}
