using System;
using System.ComponentModel;
using System.Linq.Expressions;
using WpfTogglingReadOnly.Extensions;

namespace WpfTogglingReadOnly.ViewModels
{
    /// <summary>
    /// Base View Model
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private bool _isReadOnly;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            protected set
            {
                _isReadOnly = value;
                OnPropertyChanged(this, m => m.IsReadOnly);
            }
        }

        /// <summary>
        /// Makes the view read only.
        /// </summary>
        /// <returns></returns>
        public ViewModel MakeReadOnly()
        {
            IsReadOnly = true;
            return this;
        }

        /// <summary>
        /// Makes the view model edittable.
        /// </summary>
        /// <returns></returns>
        public ViewModel MakeEdittable()
        {
            IsReadOnly = false;
            return this;
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="viewModel">The view model.</param>
        /// <param name="e">The e.</param>
        protected void OnPropertyChanged<T>(T viewModel, Expression<Func<T, object>> e)
        {
            var propertyName = e.GetPropertyName();
            var handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}