using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ClassicModels
{
    public class ClassicModelsDatabaseContext
    {
        public string ConnectionString { get; set; }

        public ClassicModelsDatabaseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
            // TODO: check database connection on start up.
        }

        public IDbConnection Conn()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
