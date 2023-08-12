using System.Data;
using System.Data.SqlClient;

namespace User_Web_Application.Infrastructure.Data
{
    /// <summary>
    /// Provides the database context to manage the database connection.
    /// </summary>
    public class DbContext
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the DbContext class with the provided configuration.
        /// </summary>
        /// <param name="configuration">The IConfiguration instance to read the connection string from.</param>
        public DbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Creates a new instance of IDbConnection for the configured database.
        /// </summary>
        /// <returns>An IDbConnection instance for the database.</returns>
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Creates and opens a new IDbConnection for the configured database.
        /// </summary>
        /// <returns>An opened IDbConnection instance for the database.</returns>
        public IDbConnection GetOpenConnection()
        {
            var connection = CreateConnection();
            connection.Open();
            return connection;
        }
    }
}
