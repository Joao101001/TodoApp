using Xamarin.Forms;
using TodoApp.Views;
using System.IO;
using TodoApp.Services;
using System;

namespace TodoApp
{
    public partial class App : Application
    {
        private static TaskDatabase _database;

        // Singleton para obtener la instancia de TaskDatabase
        public static TaskDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new TaskDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            // Pasar la base de datos a MainPage
            MainPage = new NavigationPage(new MainPage(Database));
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
