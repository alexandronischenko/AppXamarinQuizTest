using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FirstApp.Annotations;
using FirstApp.Models;
using Xamarin.Forms;

namespace FirstApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel LoginViewModel { get; set; }

        private ObservableCollection<Course> _courses;
        public INavigation Navigation { get; set; }
        public ICommand OpenCourseCommand { get; protected set; }
        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set
            {
                _courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        public MainViewModel()
        {
            OpenCourseCommand = new Command(OpenCourse);
            Courses = new ObservableCollection<Course>();
            AddData();
        }

        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                OnPropertyChanged("SelectedCourse");
            }
        }
        private void OpenCourse(object obj)
        {
            //Navigation.PushAsync(CoursesPage(obj));
        }

        private void AddData()
        {
            Courses.Add(new Course
            {
                Id = 0,
                Title = "Курс 1",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                ImagePath = "test1.jpeg"
            });
            Courses.Add(new Course
            {
                Id = 0,
                Title = "Курс 2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                ImagePath = "test2.jpeg"
            });
            Courses.Add(new Course
            {
                Id = 0,
                Title = "Курс 3",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                ImagePath = "test3.jpeg"
            });
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}