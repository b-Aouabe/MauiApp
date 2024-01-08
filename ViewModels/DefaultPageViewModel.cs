using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.DbConfig;
using MauiApp1.Models;
using MauiApp1.Views;

namespace MauiApp1.ViewModels
{
    public partial class DefaultPageViewModel(LocalDbService dbService) : ObservableObject
    {
        public readonly LocalDbService dbService = dbService;

        //public Command GoToSearchPageCommand { get; }

        //public DefaultPageViewModel()
        //{
        //    GoToSearchPageCommand = new Command(OnGoToSearchPageClicked);
        //}

        //private void OnGoToSearchPageClicked()
        //{
        //    // Navigate to the MainPage (SearchPage)
        //    App.Current.MainPage.Navigation.PushAsync(new SearchStudentPage { BindingContext = new SearchStudentViewModel()  });
        //}
        [RelayCommand]
        async Task GoToSearchPage()
        {
            await Shell.Current.GoToAsync(nameof(SearchStudentPage));
            //await App.Current.MainPage.Navigation.PushAsync(new SearchStudentPage());
        }

        [RelayCommand]
        async Task GoToAddStudentPage()
        {
            await Shell.Current.GoToAsync(nameof(AddStudentPage));
            //await App.Current.MainPage.Navigation.PushAsync(new AddStudentPage());
        }

        [RelayCommand]
        async Task GoToUpdateAbsencePage()
        {
            await Shell.Current.GoToAsync(nameof(UpdateAbsencePage));

            //await App.Current.MainPage.Navigation.PushAsync(new UpdateAbsencePage());
        }

        [RelayCommand]
        async Task GenerateDb()
        {
            List<Filiere> filieres = 
                [
                    new Filiere { Id = 1,Label="Genie Informatique" },
                    new Filiere { Id = 2,Label ="Genie Industriel" },
                    new Filiere { Id = 3,Label ="Genie Raiseaux et Telecommunication"},
                    new Filiere { Id = 3, Label ="Genie Aeronotique"},
                ];

            foreach (var filiere in filieres)
            {
                await dbService.AddField(filiere);
            }

            List<Lesson> lessons = 
                [
                    new Lesson { Id = 1, Label = "c#", FieldId = 1 },
                    new Lesson { Id = 2, Label = "java", FieldId = 1 },
                    new Lesson { Id = 3, Label = "php", FieldId = 1 },
                    new Lesson { Id = 4, Label = "analyse de donnees", FieldId = 1 },
                    new Lesson { Id = 5, Label = "python", FieldId = 1 },
                    new Lesson { Id = 6, Label = "management", FieldId = 2 },
                    new Lesson { Id = 7, Label = "Maintenance", FieldId = 2 }
                ];

            foreach (var lesson in lessons)
            {
                await dbService.AddLesson(lesson);
            }

            List<Student> students = new List<Student>
                {
                    new Student { Id=1, FirstName="John", LastName="Doe", Email="john.doe@example.com", StudentNum="12345", PhoneNumber="555-1234", FieldId=1 },
                    new Student { Id=2, FirstName="Jane", LastName="Doe", Email="jane.doe@example.com", StudentNum="67890", PhoneNumber="555-5678", FieldId=2 },
                    new Student { Id=3, FirstName="Michael", LastName="Smith", Email="michael.smith@example.com", StudentNum="11111", PhoneNumber="555-1111", FieldId=3 },
                    new Student { Id=4, FirstName="Emily", LastName="Johnson", Email="emily.johnson@example.com", StudentNum="22222", PhoneNumber="555-2222", FieldId=4 },
                    new Student { Id=5, FirstName="Daniel", LastName="Williams", Email="daniel.williams@example.com", StudentNum="33333", PhoneNumber="555-3333", FieldId=5 },
                    new Student { Id=6, FirstName="Sophia", LastName="Davis", Email="sophia.davis@example.com", StudentNum="44444", PhoneNumber="555-4444", FieldId=1 },
                    new Student { Id=7, FirstName="Liam", LastName="Brown", Email="liam.brown@example.com", StudentNum="55555", PhoneNumber="555-5555", FieldId=2 },
                    new Student { Id=8, FirstName="Olivia", LastName="Miller", Email="olivia.miller@example.com", StudentNum="66666", PhoneNumber="555-6666", FieldId=3 },
                    new Student { Id=9, FirstName="Ethan", LastName="Taylor", Email="ethan.taylor@example.com", StudentNum="77777", PhoneNumber="555-7777", FieldId=4 },
                    new Student { Id=10, FirstName="Ava", LastName="Anderson", Email="ava.anderson@example.com", StudentNum="88888", PhoneNumber="555-8888", FieldId=5 },
                    new Student { Id=11, FirstName="Mia", LastName="Moore", Email="mia.moore@example.com", StudentNum="99999", PhoneNumber="555-9999", FieldId=1 },
                    new Student { Id=12, FirstName="Noah", LastName="Jones", Email="noah.jones@example.com", StudentNum="10101", PhoneNumber="555-1010", FieldId=2 },
                    new Student { Id=13, FirstName="Emma", LastName="Thomas", Email="emma.thomas@example.com", StudentNum="12121", PhoneNumber="555-1212", FieldId=3 }
                };


            foreach (var student in students)
            {
                await dbService.AddStudent(student);
            }


            List<AbsenceHistory> absences = new List<AbsenceHistory>
            {
                new() {LessonId=1,StudentId=1,Abscences=10,Presences=25},
                new AbsenceHistory {LessonId=2,StudentId=2,Abscences=14,Presences=1},
                new AbsenceHistory {LessonId=3,StudentId=3,Abscences=5,Presences=25},
            };

            foreach (var absence in absences)
            {
                await dbService.AddAbsence(absence);
            }


        }
    }
}
