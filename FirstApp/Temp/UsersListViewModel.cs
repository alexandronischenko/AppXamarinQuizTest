using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using FirstApp.Views;

namespace FirstApp.ViewModels
{
    public class UsersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<UserViewModel> Users { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateUserCommand { protected set; get; }
        public ICommand DeleteUserCommand { protected set; get; }
        public ICommand SaveUserCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        UserViewModel _selectedUser;

        public INavigation Navigation { get; set; }

        public UsersListViewModel()
        {
            Users = new ObservableCollection<UserViewModel>();
            CreateUserCommand = new Command(CreateUser);
            DeleteUserCommand = new Command(DeleteUser);
            SaveUserCommand = new Command(SaveUser);
            BackCommand = new Command(Back);
        }

        public UserViewModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    UserViewModel tempUser = value;
                    _selectedUser = null;
                    OnPropertyChanged("SelectedUser");
                    Navigation.PushAsync(new UserPage(tempUser));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateUser()
        {
            await Navigation.PushAsync(new UserPage(new UserViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveUser(object userObject)
        {
            if (userObject is UserViewModel user && user.IsValid && !Users.Contains(user))
            {
                Users.Add(user);
            }
            Back();
        }
        private void DeleteUser(object userObject)
        {
            UserViewModel user = userObject as UserViewModel;
            if (user != null)
            {
                Users.Remove(user);
            }
            Back();
        }
    }
}