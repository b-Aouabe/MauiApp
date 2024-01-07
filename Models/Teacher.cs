﻿using SQLite;

namespace MauiApp1.Models
{
    [Table("teacher")]
    public class Teacher
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}