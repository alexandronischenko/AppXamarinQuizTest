using FirstApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage() : this(null)
        {
        }

        public MainPage(MainViewModel mvm)
        {
            InitializeComponent();
            mvm.Navigation = Navigation;
            BindingContext = mvm;
        }
    }
}
