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
        public static UserRepository database;
        public static UserRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            
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
