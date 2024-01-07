﻿
using SQLite;

namespace MauiApp1.Models
{
    [Table("student")]
    public class Student
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StudentNum { get; set; }
        public string PhoneNumber{ get; set; }
        public int FieldId { get; set; }
    }
}
