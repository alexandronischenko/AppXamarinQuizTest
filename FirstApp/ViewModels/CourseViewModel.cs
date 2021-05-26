using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FirstApp.Annotations;
using FirstApp.Models;
using Xamarin.Forms;

namespace FirstApp.ViewModels
{
    public class CourseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public ICommand CheckAnswersCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        public Course Course { get; set; }

        public static CourseViewModel Instance => new CourseViewModel();

        public CourseViewModel()
        {
            //
        }
        public CourseViewModel(Course course)
        {
            CheckAnswersCommand = new Command(CheckAnswers);
            BackCommand = new Command(Back);
            Course = course;
        }

        async void CheckAnswers()
        {
            var resultList = new List<(Question Question, bool IsCorrect)>();
            foreach (var pollQuestion in Course.Poll.Questions)
            {
                var correctAnsw = pollQuestion.CorrectAnswer;
                var selectedAnsw = pollQuestion.Answers.FirstOrDefault(x => x.IsChecked)?.Item;
                var result = selectedAnsw == correctAnsw;

                resultList.Add((pollQuestion, result));
            }

            var percentage = (double) resultList.Count(x => x.IsCorrect) / resultList.Count;

            await Application.Current.MainPage.DisplayAlert("Результат",
                $"Ваш результат: {percentage:P}\r\nПравильных ответов: {resultList.Count(x => x.IsCorrect)}/{resultList.Count}", "Ok");

            Back();
        }

        private async void Back() => await Navigation.PopModalAsync();

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
