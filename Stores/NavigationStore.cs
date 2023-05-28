﻿using MySQL_Assignment.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Assignment.Services
{
    /// <summary>
    /// Navigálást ellátó osztály, a datagrid és a Listbox View között váltogat.
    /// </summary>
    public class NavigationStore
    {
        private ViewModelBase? _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!; 
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action? CurrentViewModelChanged;
    }

}
