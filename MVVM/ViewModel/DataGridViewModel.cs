using MySQL_Assignment.Core;
using MySQL_Assignment.MVVM.Model;
using MySQL_Assignment.Repositories;
using MySQL_Assignment.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MySQL_Assignment.MVVM.ViewModel
{
    public class DataGridViewModel : ViewModelBase
    {
        private SongRepository _repo;
        private ObservableCollection<Song> _songs;
        private readonly SongStore _songStore;
        private int _index = 0;
        public int Index
        {
            get => _index;
            set 
            { 
                _index = value;
                OnPropertyChanged(nameof(Index));
            }

        }
        public IEnumerable<Song> Songs => _songs;
        public DataGridViewModel(SongStore store)
        {
            _songStore = store;
            _repo = new SongRepository();
            _songs = new(_repo.GetResults("SELECT * FROM dal"));
            this.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Index))
            {
                _songStore.GetSongDate(_repo.GetSongAndRace().ToList()[Index]);
            }
        }
    }
}
