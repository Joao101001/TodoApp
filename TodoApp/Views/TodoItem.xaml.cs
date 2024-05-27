using Xamarin.Forms;
using TodoApp.Models;
using TodoApp.Services;
using System;

namespace TodoApp.Views
{
    public partial class TodoItemPage : ContentPage
    {
        private TodoItemDatabase database;
        private TodoItem item;

        public TodoItemPage(TodoItem item)
        {
            InitializeComponent();
            database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            this.item = item;
            BindingContext = item;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                item.Name = NameEntry.Text;
                item.Description = DescriptionEditor.Text;
                await database.SaveItemAsync(item);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }


        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            await database.DeleteItemAsync(item);
            await Navigation.PopAsync();
        }
    }
}
