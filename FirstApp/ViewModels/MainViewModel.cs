using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FirstApp.Annotations;
using FirstApp.Models;

namespace FirstApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel LoginViewModel { get; set; }

        private ObservableCollection<Course> _courses;

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
            Courses = new ObservableCollection<Course>();
            AddData();
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