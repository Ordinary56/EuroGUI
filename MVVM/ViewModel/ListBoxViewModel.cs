using MySQL_Assignment.Core;
using MySQL_Assignment.MVVM.Model;
using MySQL_Assignment.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MySQL_Assignment.MVVM.ViewModel
{
    public class ListBoxViewModel : ViewModelBase
    {
        private ObservableCollection<Song> _songs;
        private SongRepository _repo;
        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged(Search);
                //ha nem akarunk kattintásra kilistázni, akkor használhatjuk ezt a módszert is!
                //Songs.Filter = FilterName;
                //Akárhányszor a Search Property értéke megváltozik, a lista azon érték szerint szűri ki
                //a címet és az előadókat, üres string esetén visszadja az összeset
            }
        }
        public CollectionView Songs { get; }
        public ICommand searchByNameCommand { get; }

        public ListBoxViewModel()
        {
            _repo = new SongRepository();
            _songs = new(_repo.GetResults("SELECT * FROM dal"));
            Songs = (CollectionView)CollectionViewSource.GetDefaultView(_songs);
            searchByNameCommand = new RelayCommand(o => { Songs.Filter = FilterName; });
            Songs.SortDescriptions.Add(new SortDescription("Artist",ListSortDirection.Ascending));
            Songs.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
        }

        private bool FilterName(object obj)
        {
            Song song = (Song)obj;
            if (string.IsNullOrEmpty(Search)) return true;
            return song.Artist.ToLower().Contains(Search.ToLower());
        }
    }
}
