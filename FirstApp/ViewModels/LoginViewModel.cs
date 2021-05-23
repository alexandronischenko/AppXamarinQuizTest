using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using FirstApp.Annotations;
using FirstApp.Models;
using FirstApp.Views;
using Xamarin.Forms;

namespace FirstApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string UserLogin { get; set; } = "alex";
        public string UserPassword { get; set; } = "12345";
        public INavigation Navigation { get; set; }
        public ICommand LoginCommand { protected set; get; }
        public ICommand RegisterCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        public static LoginViewModel Instance => new LoginViewModel();


        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
            BackCommand = new Command(Back);
        }

        async void Login()
        {
            var user = App.Database.GetItems().FirstOrDefault(x => x.Login == UserLogin && x.Password == UserPassword);
            if (user != null)
            {
                var vm = new MainViewModel { LoginViewModel = this, Navigation = this.Navigation, User = user };
                await Navigation.PushModalAsync(new MainPage(vm));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка",
                    $"Неверный логин или пароль", "Ok");
            }
        }
        private async void Register()
        {
            var isUserExists = App.Database.GetItems().Any(x => x.Login == UserLogin);

            if (isUserExists)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка",
                    $"Пользователь уже зарегистрирован", "Ok");
                return;
            }

            var result = App.Database.SaveItem(new User { Login = UserLogin, Password = UserPassword });
            if (result == 1)
                await Application.Current.MainPage.DisplayAlert("Успешно",
                    $"Пользователь зарегистрирован", "Ok");
        }
        private void Back()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
