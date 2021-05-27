using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using FirstApp.Models;
using Xamarin.Forms;

namespace FirstApp.ViewModels
{
    public class ResultViewModel
    {
        public ObservableCollection<Course> Courses { get; }
        public ICommand BackCommand { get; protected set; }
        public INavigation Navigation { get; set; }
        public static ResultViewModel Instance => new ResultViewModel();
        public ResultViewModel(ObservableCollection<Course> courses, User user)
        {
            Courses = courses;
            BackCommand = new Command(Back);

        }
        public ResultViewModel()
        {
            
        }
        private async void Back() => await Navigation.PopModalAsync();

    }
}
