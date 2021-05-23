using FirstApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursePage : ContentPage
    {
        public CoursePage()
        {
            
        }
        public CoursePage(CourseViewModel courseViewModel)
        {
            InitializeComponent();  
            BindingContext = courseViewModel;
        }
    }
}