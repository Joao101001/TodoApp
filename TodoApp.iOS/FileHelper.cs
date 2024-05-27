using System;
using System.IO;
using TodoApp.iOS;
using TodoApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace TodoApp.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
