using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Assignment.Core
{
    /// <summary>
    /// A ViewModelBase osztály ősosztálya, örökli az INotifyPropertyChanged interfészt
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Meghívja a PropertyChanged eseményt az adott tulajdonsággal, mint esemény paramétert.
        /// </summary>
        /// <param name="property">Az adott tulajdonság neve</param>
        protected void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
