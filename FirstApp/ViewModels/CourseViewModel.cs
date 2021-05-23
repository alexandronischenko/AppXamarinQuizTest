using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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
            
        }
        public CourseViewModel(Course course)
        {
            CheckAnswersCommand = new Command(CheckAnswers);
            BackCommand = new Command(Back);
            Course = course;
        }

        async void CheckAnswers()
        {
            
        }
        async void Back()
        {
            
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
