using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Assignment.MVVM.Model
{
    public class Race
    {
        public Race(int year, DateTime date, string city, string country, int number)
        {
            Year = year;
            Date = date;
            City = city;
            Country = country;
            Number = number;
        }
        public int Year { get; }
        public DateTime Date { get; }
        public string City { get; }
        public string Country { get; }
        public int Number { get; }
        

    }
}
