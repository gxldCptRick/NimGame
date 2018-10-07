using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Nim.UI.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// event to signal that a property has been changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// method used to signal the property has changed its value
        /// </summary>
        /// <param name="propertyName"></param>
        protected void PropertyChanging([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}