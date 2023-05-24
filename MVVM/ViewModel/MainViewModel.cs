using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MySQL_Assignment.Core;
using MySQL_Assignment.MVVM.Model;
using MySQL_Assignment.Repositories;

namespace MySQL_Assignment.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Song> _songs;
        private SongRepository _repo;
        public IEnumerable<Song> Songs
        {
            get => _songs;
        }
        public ICommand Command { get; }
        public MainViewModel()
        {
            _repo = new SongRepository();
            _songs = new ObservableCollection<Song>(_repo.GetSongs());
        }


    }
}
