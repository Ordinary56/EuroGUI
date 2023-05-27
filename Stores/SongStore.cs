using MySQL_Assignment.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Assignment.Stores
{
    /// <summary>
    /// Média közeg a ViewModellek között (ebben az esetben a MainVM és a DataGridVM között)
    /// Ennek segítségével tudnak kommunikálni egymással.
    /// </summary>
    /// <remarks>A DatagridViewModel a publisher (kiadó), addig a MainVM a subscriber (feliratkozó).</remarks>
    public class SongStore
    {
        public event Action<Song>? SongSelected;
        public void GetSongDate(Song song)
        {
            SongSelected?.Invoke(song);
        }
    }
}
