using Npgsql;
using System.Data.SqlClient;

namespace SSS.Models
{
    public class conexion
    {
        public SqlConnection conn;
        public SqlCommand sen;
        public SqlDataReader rs;

        public NpgsqlConnection connections()
        {

            string conString = "Server=192.168.0.45;Port=5432; Userid=postgres;Password=postgres; Pooling=true;MinPoolSize=1; MaxPoolSize=20;Timeout=15;Database=sss_db";

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(conString);

            return connection;

        }
    }
}