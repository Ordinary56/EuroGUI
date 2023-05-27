using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySQL_Assignment.Core;
using MySQL_Assignment.MVVM.ViewModel;
using MySQL_Assignment.Services;
using MySQL_Assignment.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MySQL_Assignment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigation;
        readonly SongStore songStore;
        public App()
        {
            navigation = new NavigationStore();
            songStore = new SongStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigation, songStore)
            };
            MainWindow.Show();
            
            base.OnStartup(e);
        }
    }
}
