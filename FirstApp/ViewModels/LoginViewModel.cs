using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using FirstApp.Annotations;
using Xamarin.Forms;

namespace FirstApp.ViewModels
{
    class LoginViewModel:INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public ICommand LoginCommand { protected set; get; }
        public ICommand RegisterCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand= new Command(Register);
            BackCommand = new Command(Back);
        }

        private void Login()
        {

        }
        private void Register()
        {

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
