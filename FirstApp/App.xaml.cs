using System;
using System.IO;
using FirstApp.DataBase;
using FirstApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "StudyDataBase.db";
        public static UserRepository userDatabase;
        public static UserRepository UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return userDatabase;
            }
        }public static CourseRepository courseDatabase;
        public static CourseRepository CourseDatabase
        {
            get
            {
                if (courseDatabase == null)
                {
                    courseDatabase = new CourseRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return courseDatabase;
            }
        }
       
        public App()
        {
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
