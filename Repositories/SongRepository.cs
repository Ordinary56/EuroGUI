using MySql.Data.MySqlClient;
using MySQL_Assignment.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Assignment.Repositories
{
    public class SongRepository : RepositoryBase
    {
        public IEnumerable<Song> GetSongs()
        {
            using(MySqlConnection connection = GetConnection())
            using(MySqlCommand command = new MySqlCommand("SELECT * FROM dal",connection))
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Song(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                            reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)
                            );
                    }
                }

            }
        }
    }
}
