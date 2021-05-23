using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp.UserControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizContainer : ContentView
    {
        public QuizContainer()
        {
            InitializeComponent();
        }
    }
}