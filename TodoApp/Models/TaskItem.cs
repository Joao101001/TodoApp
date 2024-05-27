using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TodoApp.Models
{
    public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
