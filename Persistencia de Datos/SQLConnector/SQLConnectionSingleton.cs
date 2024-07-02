/*using System.Data.SqlClient;
namespace Persistencia_de_Datos.SQLConnector
{
    public class SQLConnectionSingleton
    {
        private static SQLConnectionSingleton instance = null;
        private SqlConnection connection;
        private SQLConnectionSingleton(string server, string database, string valor)
        {
            string connectionString = $"Data source={server};Initial Catalog={database};Integrated Security={valor}";
            connection = new SqlConnection(connectionString);
        }

        public static SQLConnectionSingleton Instance
            (string server, string database, string valor)
        {
            if (instance == null)
            {
                instance = new SQLConnectionSingleton(server, database, valor);
            }
            return instance;
        }
        public SqlConnection GetConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed || connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Open();
            }
            return connection;
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
