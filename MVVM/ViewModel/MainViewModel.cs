using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using MySQL_Assignment.Core;
using MySQL_Assignment.MVVM.Model;
using MySQL_Assignment.Repositories;
using MySQL_Assignment.Services;
using MySQL_Assignment.Stores;

namespace MySQL_Assignment.MVVM.ViewModel
{
    /// <summary>
    /// A fő ViewModel. A MainWindow.xaml-hez tartozik
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private SongRepository _repo;
        private string _results;
        private DateTime _songDate;
        private readonly SongStore _songStore;
        public string Results
        {
            get => _results;
            set
            {
                _results = value;
                OnPropertyChanged(nameof(Results)); 
            }
        }
        public DateTime SongDate
        {
            get => _songDate;
            set
            {
                _songDate = value;
                OnPropertyChanged(nameof(SongDate));
            }
        }

        public ICommand NavigateToTaskSevenCommand { get; }
        public ICommand NavigateToDGCommand { get; }
        public ICommand TaskFourCommand { get; }
        public ICommand TaskFiveCommand { get; }
        public ICommand TaskSixCommand { get; }
        public ICommand GetDateCommand { get; }


        private NavigationStore _navigationStore;
        public ViewModelBase CurrentVM => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigation, SongStore store)
        {
            _navigationStore = navigation;
            _songStore = store;
            _navigationStore.CurrentViewModel = new DataGridViewModel(_songStore);
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
            TaskFourCommand = new RelayCommand(TaskFour);
            TaskFiveCommand = new RelayCommand(TaskFive);
            NavigateToTaskSevenCommand = new RelayCommand( o => { _navigationStore.CurrentViewModel = new ListBoxViewModel(); });
            NavigateToDGCommand = new RelayCommand(o => { _navigationStore.CurrentViewModel = new DataGridViewModel(_songStore); });
            GetDateCommand = new RelayCommand(o => { _songStore.SongSelected += GetSongDate; });
            //Ha azt akarjuk, hogy abban a pillanatban, mikor kiválasztjuk a datagrid egy elemét
            //jelenjen meg annak a versenynek a dátuma, az alábbi kódrészlet megteszi.
            //_songStore.SongSelected += GetSongDate;
            _repo = new SongRepository();
        }

        private void GetSongDate(Song obj)
        {
            SongDate = obj.ORace!.Date;
        }

        private void _navigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }

        void TaskFour(object parameter)
        {
            List<Song> query = _repo.GetResults("SELECT * FROM dal  WHERE dal.orszag='Magyarország'").ToList();
            Results = $"Ennyi magyarországi versenyző van: {query.Count()}\n A legjobb elért helyezés: {query.Min(x => x.Placement)}";

        }

        void TaskFive(object parameter)
        {
            double query = _repo.GetResults("SELECT * FROM dal  WHERE dal.orszag='Németország'").ToList().Average(x => x.Score);
            Results = $"Németország pontszámának átlaga: {query:F2}";
        }


    }
}
