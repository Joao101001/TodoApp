using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }

}
