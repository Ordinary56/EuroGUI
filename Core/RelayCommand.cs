using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MySQL_Assignment.Core
{
    /// <summary>
    /// RelayCommand osztály. Segítségével parancsokat (commandokat)
    /// tudunk gombokhoz, vezérlő egységekhez parancsokat rendelni
    /// </summary>
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private Action<object> _execute;
        private Predicate<object> _canexecute;
        /// <param name="execute">Az adott parancs, amit a RelayCommand le fog futtatni</param>
        /// <param name="canexecute">Megnézi, hogy az adott parancs megfelel az adott feléltelnek</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action<object> execute, Predicate<object> canexecute)
        {
            _execute = execute ?? throw new ArgumentNullException("No command was given to RelayCommand");
            _canexecute = canexecute;
        }
#pragma warning disable
        /// <param name="execute">Az adott parancs, amit a RelayCommand le fog futtatni.
        /// Ebben az esetben a parancs bármikor lefuttatható.</param>
        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public bool CanExecute(object? parameter)
        {
            return _canexecute == null || _canexecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
