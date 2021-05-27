using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public ResultPage(ResultViewModel resultViewModel)
        {
            InitializeComponent();
            BindingContext = resultViewModel;
        }
    }
}