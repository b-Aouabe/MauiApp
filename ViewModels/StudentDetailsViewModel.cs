using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{ 
    public partial class StudentDetailsViewModel : ObservableObject
    {

        //after getting the student and the course from the search page here i will search in the abssences table
        //for the total abssebces and presences of that student in that specific course

        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private int lessonid;

        [ObservableProperty]
        private int abssences = 0;

        [ObservableProperty]
        private int presences = 0;

        public StudentDetailsViewModel (Student student, Lesson lesson)
        {
            this.firstName = student.FirstName;
            this.lastName = student.LastName;
            this.lessonid = lesson.Id;
        }



    }

}
