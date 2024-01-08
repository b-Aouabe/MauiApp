using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.DbConfig;
using MauiApp1.Models;

namespace MauiApp1.ViewModels
{ 
    public partial class StudentDetailsViewModel : ObservableObject
    {

        //after getting the student and the course from the search page here i will search in the abssences table
        //for the total abssebces and presences of that student in that specific course
        [ObservableProperty]
        private string studentName;


        [ObservableProperty]
        private string lesson;

        [ObservableProperty]
        private string absences;

        [ObservableProperty]
        private string presences;

        public StudentDetailsViewModel (AbsenceHistory histoy,string lessonName,string studentName)
        {
            this.lesson = lessonName;
            this.studentName = studentName;
            Presences = $"Presences : {histoy.Presences}";
            Absences = $"Absences : {histoy.Abscences}";
        }



    }

}
