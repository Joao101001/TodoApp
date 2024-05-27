using Xamarin.Forms;
using TodoApp.Models;
using TodoApp.Services;
using System;
using TodoApp.Views;

namespace TodoApp
{
    public partial class MainPage : ContentPage
    {
        private readonly TaskDatabase _database;

        public MainPage(TaskDatabase database = null)
        {
            InitializeComponent();
            _database = database ?? App.Database; // Usar la base de datos proporcionada o la predeterminada de la aplicación
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TasksListView.ItemsSource = await _database.GetTasksAsync();
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskPage(_database));
        }

        private async void OnTaskTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var task = e.Item as TaskItem;
                await Navigation.PushAsync(new TaskPage(_database, task));
            }
        }

        private async void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var task = menuItem.CommandParameter as TaskItem;

            if (task != null)
            {
                var result = await DisplayAlert("Confirmar", $"¿Está seguro que desea eliminar la tarea '{task.Name}'?", "Sí", "No");
                if (result)
                {
                    await _database.DeleteTaskAsync(task);
                    TasksListView.ItemsSource = await _database.GetTasksAsync();
                }
            }
        }
    }
}
