using FirstApp.ViewModels;
using Xamarin.Forms;

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
