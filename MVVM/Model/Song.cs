using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Assignment.MVVM.Model
{
    public class Song
    {
        public Song(int id, int year, string country, string artist, string title, int placement, int score, Race? oRace = null)
        {
            Id = id;
            Year = year;
            Country = country;
            Artist = artist;
            Title = title;
            Placement = placement;
            Score = score;
            ORace = oRace;
        }


        public int Id { get;  }
        public int Year { get; }
        public string Country { get; }
        public string Artist { get; }
        public string Title { get; }
        public int Score { get; }
        public int Placement { get; }

        public Race? ORace { get; }
        
    }
}
