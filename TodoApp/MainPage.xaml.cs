using Xamarin.Forms;
using TodoApp.Models;
using TodoApp.Services;
using System;

namespace TodoApp.Views
{
    public partial class MainPage : ContentPage
    {
        private TodoItemDatabase database;

        public MainPage()
        {
            InitializeComponent();
            database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            LoadData();
        }

        private async void LoadData()
        {
            TodoListView.ItemsSource = await database.GetItemsAsync();
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage(new TodoItem()));
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage((TodoItem)e.SelectedItem));
            }
        }
    }
}
