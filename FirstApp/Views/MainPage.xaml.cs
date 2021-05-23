using FirstApp.ViewModels;
using Xamarin.Forms;

namespace FirstApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MainViewModel mvm = new MainViewModel
            {
                Navigation = Navigation
            };
            BindingContext = mvm;
        }
    }
}
