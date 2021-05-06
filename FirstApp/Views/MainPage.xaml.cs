using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstApp.ViewModels;
using Xamarin.Forms;

namespace FirstApp.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel ViewModel { get; set; }
        public MainPage(MainViewModel vm)
        { 
            InitializeComponent();
            
            ViewModel = vm;
            BindingContext = ViewModel;
        }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            BindingContext = ViewModel;
        }
    }
}
