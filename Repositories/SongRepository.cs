using MySql.Data.MySqlClient;
using MySQL_Assignment.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Assignment.Repositories
{
    public class SongRepository : RepositoryBase
    {
        //LINQ-s megoldás,
        //adatok beolvasása (NINCS SQL INJECTION ELLENI VÉDELEM!!!)
        public IEnumerable<Song> GetResults(string commandstring)
        {
            if (string.IsNullOrEmpty(commandstring)) yield break;
            using (MySqlConnection connection = GetConnection())
            using (MySqlCommand command = new MySqlCommand(commandstring, connection))
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
                connection.Close();
            }
        }
        public IEnumerable<Song> GetSongAndRace() 
        {
            using (MySqlConnection connection = GetConnection())
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM dal INNER JOIN verseny ON dal.ev=verseny.ev;", connection))
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Song(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                            reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6),
                            new Race(reader.GetInt32(7),reader.GetDateTime(8),reader.GetString(9),
                            reader.GetString(10),reader.GetInt32(11))
                            );
                    }
                }
                connection.Close();
            }
        }

    }
}


      

    

