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

        void Exit()
        {
            Application.Current.Quit();
            //await Navigation.PopToRootAsync(true);
        }
        async void OpenCourse()
        {
            //await Application.Current.MainPage.Navigation.PushModalAsync(new CoursePage(new CourseViewModel(SelectedCourse)));
            await Navigation.PushModalAsync(new CoursePage(new CourseViewModel(SelectedCourse){Navigation = Navigation}));
        }

        private void AddData()
        {
            var items = new Course[]
            {
                new Course
                {
                    Id = 0,
                    Title = "Тест: как хорошо ты знаешь Шерлока Холмса?",
                    Description = "Тест: как хорошо ты знаешь Шерлока Холмса?",
                    ImagePath = "test1.jpeg",
                    Lecture = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent faucibus.",
                    Poll = new Poll(new ObservableCollection<Question>{
                        new Question("Что король подарил Шерлоку Холмсу за раскрытие дела в «Скандале в Богемии»?", new ObservableCollection<string> { ("Изумрудное кольцо"), ("Фотографию"), ("Персидские туфли")},"Фотографию"),
                        new Question("Сколько было зернышек апельсина в одноименном рассказе?", new ObservableCollection<string> {("2"),("5"),("7")}, "2"),
                        new Question("Какой из этих сюжетов не был экранизирован в сериале с Бенедиктом Камбербэтчем?", new ObservableCollection<string> { ("«Пестрая лента»"), ("«Этюд в багровых тонах»"), ("«Шесть Наполеонов»")}, "«Пестрая лента»"),
                        new Question("Что из этого не делает «книжный» Шерлок Холмс?", new ObservableCollection<string> { ("Не говорит «Элементарно, Ватсон»"), ("Не курит трубку"), ("Не носит шляпу") }, "Не говорит «Элементарно, Ватсон»"),
                        new Question("Что король подарил Шерлоку Холмсу за раскрытие дела в «Скандале в Богемии»?", new ObservableCollection<string> { ("Изумрудное кольцо"), ("Фотографию"), ("Персидские туфли")},"Фотографию"),
                        new Question("Сколько было зернышек апельсина в одноименном рассказе?", new ObservableCollection<string> {("2"),("5"),("7")}, "2"),
                        new Question("Какой из этих сюжетов не был экранизирован в сериале с Бенедиктом Камбербэтчем?", new ObservableCollection<string> { ("«Пестрая лента»"), ("«Этюд в багровых тонах»"), ("«Шесть Наполеонов»")}, "«Пестрая лента»"),
                        new Question("Что из этого не делает «книжный» Шерлок Холмс?", new ObservableCollection<string> { ("Не говорит «Элементарно, Ватсон»"), ("Не курит трубку"), ("Не носит шляпу") }, "Не курит трубку")
                        })
                },
                new Course
                {
                    Id = 1,
                    Title = "Курс 2",
                    Description = "Шуточный тест для проверки, на самом ли деле вы программист или только так считаете. Также отлично вычисляет гуманитариев. Попробуйте.",
                    ImagePath = "test2.jpeg",
                    Lecture = "Шуточный тест для проверки, на самом ли деле вы программист или только так считаете. Также отлично вычисляет гуманитариев. Попробуйте.",
                    Poll = new Poll(new ObservableCollection<Question>
                    {
                        new Question("Какую первую программу обычно пишут программисты?",new ObservableCollection<string> { "Hello world", "Сортировку «пузырьком»", "Для взлома аккаунта «ВКонтакте». Такая программа есть у каждого программиста"},  "Hello world"),
                        new Question("Бывает ли так, что программа скомпилировалась с первого раза и без ошибок?",new ObservableCollection<string> { "Да, конечно", "Нет, это фантастика", "Затрудняюсь ответить"},  "Нет, это фантастика"),
                        new Question("Представим гипотетическую ситуацию, в которой программа всё-таки скомпилировалась с первого раза. Как вы поступите?",new ObservableCollection<string> { "Выключу комп и спокойно пойду спать — дело сделано", "Порадуюсь за себя и продолжу писать код", "Буду искать ошибку в компиляторе, где-то она должна быть"},  "Буду искать ошибку в компиляторе, где-то она должна быть"),
                        new Question("Допустим, вы пишете проект, и заказчик утвердил документ, в котором чётко написано, что он хочет получить в результате. Назовём его ТЗ. Изменятся ли требования в процессе работы над проектом?",new ObservableCollection<string> { "Изменятся, конечно", "Не изменятся. Вы же сами сказали, что всё чётко зафиксировано", "Затрудняюсь ответить"},  "Изменятся, конечно"),
                        new Question("Какой правильный ответ на вопрос про рекурсию?",new ObservableCollection<string> { "Да", "42", "Какой правильный ответ на вопрос про рекурсию?"},  "Какой правильный ответ на вопрос про рекурсию?"),
                        new Question("Представьте, что вы пишете программу и при попытке её сборки компилятор выдал вам одну ошибку. Вы исправили её и пробуете собрать проект ещё раз. Сколько теперь будет ошибок?",new ObservableCollection<string> { "Была одна, теперь ошибок не будет", "Неизвестно", "Затрудняюсь ответить"},  "Неизвестно"),
                        new Question("Вы пришли на проект, над которым раньше работал другой программист. Что можно сказать о его коде?",new ObservableCollection<string> { "Надо сначала детально изучить проект, чтобы понять это", "Его код просто ужасен, ну кто так пишет!", "Затрудняюсь ответить"},  "Его код просто ужасен, ну кто так пишет!"),
                        new Question("Перед вами три дерева. На том, что посередине, сидит кот. На дереве с каким индексом сидит кот?",new ObservableCollection<string> { "2", "1", "0"},  "1"),
                    })
                },
                new Course
                {
                  Id = 2,
                  Title = "Терминология",
                  Description = "Терминология",
                  ImagePath = "test3.jpeg",
                  Lecture = "Кодовый файл — это один из файлов на языке C#. Проект — это совокупность кодовых файлов, которые могут быть скомпилированы в сборку: программу или библиотеку. Сборка — это, соответственно, результат компиляции проекта. Как правило это *.exe или *.dll файл, содержащий инструкции для компьютера. Решение (solution) — это несколько проектов, объединенные общими библиотеками и задачами. Как правило открывать с помощью Visual Studio нужно именно файл решения (.sln), хотя можно открыть и отдельный проект (.csproj файл). Имейте в виду, если открыть отдельный кодовый файл, не открывая проект или решение, то не будет возможности его запустить. Это распространённая ошибка новичков. Reference — ссылка внутри проекта на другие сборки. Только сославшись на другую сборку можно будет использовать код из неё. Метод — это последовательность действий. Аналог функций, процедур и подпрограмм в других языках. В устной речи часто используют все эти слова как синонимы, но в спецификации на язык C# используется термин «метод». Класс — это совокупность данных и методов. Все сборки состоят из скомпилированных классов. Пространство имен — это совокупность классов, логически связанных между собой. Между сборками и пространствами имен нет прямого соответствия: в сборке может хранится несколько пространств имен, а разные классы одного пространства имен могут быть определены в разных сборках. После успешной компиляции, в директории проекта создается поддиректория bin/Debug, в которой и оказывается сборка — результат компиляции — exe или dll файлы вашей программы.",
                  Poll = new Poll(new ObservableCollection<Question>
                  {
                      new Question("Как в языке C# называют именованную последовательность инструкций",new ObservableCollection<string> { "Функция", "Подпрограмма", "Метод"},  "Метод"),
                      new Question("Что перечисляется в секции References (ссылки) проекта в Visual Studio (или других IDE)",new ObservableCollection<string> { "Пространства имён, доступные для использования в кодовых файлах проекта", "Сборки, классы которых доступны для использования в кодовых файлах проекта", "Пространства имён, определённые в этом проекте"},  "Сборки, классы которых доступны для использования в кодовых файлах проекта"),
                      new Question("Каково предназначение инструкции using в начале кодового файла?",new ObservableCollection<string> { "Подключает стороннюю библиотеку, открывая возможность пользоваться её классами", "Избавляет программиста от необходимости указывать пространство имён перед именами классов данного пространства имён, сокращая код", "Затрудняюсь ответить"},  "Избавляет программиста от необходимости указывать пространство имён перед именами классов данного пространства имён, сокращая код"),
                      new Question("Где найти exe-файл — результат компиляции моего проекта",new ObservableCollection<string> { "Скорее всего в подпапке bin/Debug папки вашего проекта", "В текущей директории", "Нигде, программа запускается, без создания exe-файла"},  "Скорее всего в подпапке bin/Debug папки вашего проекта"),
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