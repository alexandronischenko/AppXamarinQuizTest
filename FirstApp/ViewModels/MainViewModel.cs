using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FirstApp.Annotations;
using FirstApp.Models;
using FirstApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FirstApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel LoginViewModel { get; set; }
        private ObservableCollection<Course> _courses;
        public INavigation Navigation { get; set; }
        public ICommand OpenCourseCommand { get; protected set; }
        public ICommand ExitCommand { get; protected set; }
        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set
            {
                _courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        public static MainViewModel Instance => new MainViewModel();
        public MainViewModel()
        {
            OpenCourseCommand = new Command(OpenCourse);
            ExitCommand = new Command(Exit);
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

        public User User { get; set; }

        async void Exit()
        {
            await Navigation.PopToRootAsync(true);
        }
        async void OpenCourse()
        {
            //await Application.Current.MainPage.Navigation.PushModalAsync(new CoursePage(new CourseViewModel(SelectedCourse)));
            await Navigation.PushModalAsync(new CoursePage(new CourseViewModel(SelectedCourse){Navigation = Navigation}));
        }

        private void AddData()
        {
            var q1 = new Question[]
            {
                new Question("Что король подарил Шерлоку Холмсу за раскрытие дела в «Скандале в Богемии»?", new ObservableCollection<string> { ("Изумрудное кольцо"), ("Фотографию"), ("Персидские туфли")},"Фотографию"),
                new Question("Сколько было зернышек апельсина в одноименном рассказе?", new ObservableCollection<string> {("2"),("5"),("7")}, "2"),
                new Question("Какой из этих сюжетов не был экранизирован в сериале с Бенедиктом Камбербэтчем?", new ObservableCollection<string> { ("«Пестрая лента»"), ("«Этюд в багровых тонах»"), ("«Шесть Наполеонов»")}, "«Пестрая лента»"),
                new Question("Что из этого не делает «книжный» Шерлок Холмс?", new ObservableCollection<string> { ("Не говорит «Элементарно, Ватсон»"), ("Не курит трубку"), ("Не носит шляпу") }, "Не говорит «Элементарно, Ватсон»"),
                new Question("Что король подарил Шерлоку Холмсу за раскрытие дела в «Скандале в Богемии»?", new ObservableCollection<string> { ("Изумрудное кольцо"), ("Фотографию"), ("Персидские туфли")},"Фотографию"),
                new Question("Сколько было зернышек апельсина в одноименном рассказе?", new ObservableCollection<string> {("2"),("5"),("7")}, "2"),
                new Question("Какой из этих сюжетов не был экранизирован в сериале с Бенедиктом Камбербэтчем?", new ObservableCollection<string> { ("«Пестрая лента»"), ("«Этюд в багровых тонах»"), ("«Шесть Наполеонов»")}, "«Пестрая лента»"),
                new Question("Что из этого не делает «книжный» Шерлок Холмс?", new ObservableCollection<string> { ("Не говорит «Элементарно, Ватсон»"), ("Не курит трубку"), ("Не носит шляпу") }, "Не курит трубку")
            };
            var items = new Course[]
            {
                new Course
                {
                    Id = 0,
                    Title = "Тест: как хорошо ты знаешь Шерлока Холмса?",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                    ImagePath = "test1.jpeg",
                    Lecture = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                    Poll = new Poll(new ObservableCollection<Question>(q1))
                },
                new Course
                {
                    Id = 1,
                    Title = "Курс 2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                    ImagePath = "test2.jpeg",
                    Lecture = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                    Poll = new Poll(new ObservableCollection<Question>
                    {
                        new Question("Сколько",new ObservableCollection<string> {"1","2","3"},  "1"),
                        new Question("Сколько",new ObservableCollection<string> {"1","2","3"},  "1"),
                        new Question("Сколько",new ObservableCollection<string> {"1","2","3"},  "1")
                    })
                },
                new Course
                {
                  Id = 2,
                  Title = "Курс 3",
                  Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                  ImagePath = "test3.jpeg",
                  Lecture = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                  Poll = new Poll(new ObservableCollection<Question>
                  {
                      new Question("Сколько",new ObservableCollection<string> {"1","2","3"},  "1"),
                      new Question("Сколько",new ObservableCollection<string> {"1","2","3"},  "1"),
                      new Question("Сколько",new ObservableCollection<string> {"1","2","3"},  "1"),
                  })
                }

            };

            Courses = new ObservableCollection<Course>(items);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}