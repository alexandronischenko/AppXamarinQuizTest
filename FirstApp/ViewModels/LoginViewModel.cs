﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using FirstApp.Annotations;
using FirstApp.Views;
using Xamarin.Forms;

namespace FirstApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public ICommand LoginCommand { protected set; get; }
        public ICommand RegisterCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
            BackCommand = new Command(Back);
        }

        async void Login()
        {
            var vm = new MainViewModel { LoginViewModel = this, Navigation = this.Navigation };
            await Navigation.PushModalAsync(new MainPage());
        }
        private void Register()
        {
            //klhjhk
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
