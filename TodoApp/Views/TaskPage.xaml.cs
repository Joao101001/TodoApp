using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        private readonly TaskDatabase _database;
        private TaskItem _taskItem;

        public TaskPage(TaskDatabase database, TaskItem taskItem = null)
        {
            InitializeComponent();
            _database = database;
            _taskItem = taskItem;

            if (_taskItem != null)
            {
                TaskNameEntry.Text = _taskItem.Name;
                TaskDescriptionEntry.Text = _taskItem.Description;
            }
        }

        private async void OnSaveTaskClicked(object sender, EventArgs e)
        {
            try
            {
                if (_taskItem == null)
                {
                    _taskItem = new TaskItem
                    {
                        Name = TaskNameEntry.Text,
                        Description = TaskDescriptionEntry.Text
                    };
                }
                else
                {
                    _taskItem.Name = TaskNameEntry.Text;
                    _taskItem.Description = TaskDescriptionEntry.Text;
                }

                await _database.SaveTaskAsync(_taskItem);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al guardar la tarea: {ex.Message}", "OK");
            }
        }

    }

}