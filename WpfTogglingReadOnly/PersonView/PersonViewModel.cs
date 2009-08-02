using System.Windows.Input;
using WpfTogglingReadOnly.Commands;
using WpfTogglingReadOnly.ViewModels;

namespace WpfTogglingReadOnly.PersonView
{
    /// <summary>
    /// Person View Model
    /// </summary>
    public class PersonViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonViewModel"/> class.
        /// </summary>
        public PersonViewModel()
        {
            ToggleReadOnlyCommand = new ActionCommand(ToggleReadOnly);

            FirstName = "First Name";
            LastName = "Last Name";
        }

        private string _firstName;
        private string _lastName;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(this, m => m.FirstName);
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(this, m => m.LastName);
            }
        }

        /// <summary>
        /// Gets or sets the toggle read only command.
        /// </summary>
        /// <value>The toggle read only command.</value>
        public ICommand ToggleReadOnlyCommand { get; set; }

        /// <summary>
        /// Toggles the read only status of view model.
        /// </summary>
        private void ToggleReadOnly()
        {
            if (IsReadOnly)
                MakeEdittable();
            else
                MakeReadOnly();
        }
    }
}