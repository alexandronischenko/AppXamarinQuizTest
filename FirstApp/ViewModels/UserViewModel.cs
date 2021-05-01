using System.ComponentModel;
using System.Runtime.CompilerServices;
using FirstApp.Annotations;
using FirstApp.Models;
using FirstApp.Views;

namespace FirstApp.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        UsersListViewModel lvm;
        public User User { get; private set; }

        public UserViewModel()
        {
            User = new User();
        }

        public UsersListViewModel ListViewModel
        {
            get{
                return lvm;
            }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return User.Name; }
            set
            {
                if (User.Name != value)
                {
                    User.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Email
        {
            get { return User.Email; }
            set
            {
                if (User.Email != value)
                {
                    User.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Phone
        {
            get { return User.Phone; }
            set
            {
                if (User.Phone!= value)
                {
                    User.Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Name.Trim())
                       || !string.IsNullOrEmpty(Email.Trim())
                       || !string.IsNullOrEmpty(Phone.Trim());
            }
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}