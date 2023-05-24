using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MySQL_Assignment.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=eurovizio;";

        protected MySqlConnection GetConnection() 
        {
            return new MySqlConnection(connectionString);
        }

    }
}
