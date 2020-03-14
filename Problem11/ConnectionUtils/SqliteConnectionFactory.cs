using System;
using System.Data;
using Mono.Data.Sqlite;

namespace Problem11.ConnectionUtils
{
    public class SqliteConnectionFactory : ConnectionFactory
    {
        public override IDbConnection CreateConnection()
        {
            string connectionString = "URI=file:/Users/mariangeorge/Downloads/Curs2/DataBase/Curse.db,Version=3";
            return new SqliteConnection(connectionString);
        }
    }
}
