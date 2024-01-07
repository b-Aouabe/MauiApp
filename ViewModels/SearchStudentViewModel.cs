using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        [ObservableProperty]        
        private string firstName;

        [ObservableProperty] 
        private string lastName;   

        [ObservableProperty]
        private Filiere fieldOfStudy;

        [ObservableProperty]
        ObservableCollection<Filiere> fields = [
            new Filiere { Id = 1, Label = "Computer Science" },
            new Filiere { Id = 2, Label = "Electrical Engineering" },
            new Filiere { Id = 3, Label = "Civil Engineering" }
            ];

        [ObservableProperty]
        private Lesson selectedlesson;

        [ObservableProperty]
        ObservableCollection<Lesson> lessons = [
            new Lesson { Id = 1, Label = "Computer Science" },
            new Lesson { Id = 2, Label = "Electrical Engineering" },
            new Lesson { Id = 3, Label = "Civil Engineering" }
            ];

        [RelayCommand]
         private void Search()
        {
            //todo : search the student in the db
            // Create an instance of StudentModel with the entered information
            Student student = new Student
            {
                Id = 1,
                FirstName = FirstName,
                LastName = LastName,
            };

            // Navigate to the DetailsPage and pass the StudentModel

            App.Current.MainPage.Navigation.PushAsync(new DetailsPage() { BindingContext = new StudentDetailsViewModel(student, selectedlesson) });
        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..", animate: true);
        }
    }

}
