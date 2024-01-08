using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.DbConfig;
using MauiApp1.Models;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
     public partial class SearchStudentViewModel : ObservableObject
     {
        readonly LocalDbService dbService;
        public SearchStudentViewModel(LocalDbService dbService)
        {
            this.dbService = dbService;
            SetFields();
            SetLessons();
        }
        [ObservableProperty]        
        private string firstName;

        [ObservableProperty] 
        private string lastName;   

        [ObservableProperty]
        private Filiere fieldOfStudy;

        [ObservableProperty]
        ObservableCollection<Filiere> fields = [];

        [ObservableProperty]
        private Lesson selectedlesson;

        [ObservableProperty]
        ObservableCollection<Lesson> lessons = [];

         [RelayCommand]
         async Task Search()
        {
            //todo : search the student in the db
            // Create an instance of StudentModel with the entered information

            try
            {
                var student = await dbService.GetStudentByFirstLastName(FirstName, LastName);
                var absenceHistory = await dbService.GetAbsencesByLessonStudent(selectedlesson.Id,student.Id);
                await App.Current.MainPage.Navigation.PushAsync(new DetailsPage() { BindingContext = new StudentDetailsViewModel(absenceHistory,Selectedlesson.Label,student.FirstName+" "+student.LastName) });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error","Error :"+ex.Message,"Ok");
            }

            // Navigate to the DetailsPage and pass the StudentModel

        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..", animate: true);
        }

        async Task SetFields()
        {
            var allFields = await dbService.GetAllFields();
            Fields.Clear();
            foreach (var obj in allFields)
            {
                Fields.Add(obj);
            }
        }

        public async Task SetLessons()
        {
            List<Lesson> allLessons;
            if (FieldOfStudy == null)
            {
                allLessons = await dbService.GetAllLessons();
            }
            else
            {
                allLessons = await dbService.GetLessonsByFieldId(FieldOfStudy.Id);
            }
            Lessons.Clear();
            foreach (var obj in allLessons)
            {
                Lessons.Add(obj);
            }
        }
    }

}
