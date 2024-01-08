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

        static List<Student> GenerateStudents()
        {
            List<Student> students = new List<Student>();

            string[] firstNames = { "Liam", "Emma", "Noah", "Olivia", "Sophia", "Jackson", "Ava", "Isabella", "Lucas", "Mia", "Liam", "Ethan", "Oliver", "Aiden", "Harper", "Ella", "Mila", "Emily", "Amelia", "Abigail", "Aiden", "Jackson", "Madison", "Avery", "Evelyn" };

            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Jackson", "Taylor", "Thomas", "Harris", "Moore", "Martin", "White", "Hall", "Thompson", "Gomez", "Walker", "Perez", "Turner", "Lopez", "Cooper" };

            for (int i = 1; i <= 25; i++)
            {
                students.Add(new Student
                {
                    Id = i,
                    FirstName = firstNames[i - 1],
                    LastName = lastNames[i - 1],
                    Email = $"{firstNames[i - 1].ToLower()}.{lastNames[i - 1].ToLower()}@example.com",
                    StudentNum = $"55555{i}",
                    PhoneNumber = $"555-5555{i}",
                    FieldId = (i - 1) / 5 + 1 // Distribute FieldId in groups of 5
                });
            }

            return students;
        }

        [RelayCommand]
        async Task Logout()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task GenerateDb()
        {
            List<Filiere> filieres = 
                [
                    new Filiere { Id = 1,Label="Genie Informatique" },
                    new Filiere { Id = 2,Label ="Genie Industriel" },
                    new Filiere { Id = 3,Label ="Genie Raiseaux et Telecommunication"},
                    new Filiere { Id = 4, Label ="Genie Aeronotique"},
                    new Filiere { Id = 5, Label ="Genie De Procedes"},
                ];

            foreach (var filiere in filieres)
            {
                await dbService.AddField(filiere);
            }

            List<Lesson> lessons = 
                [
                    new Lesson { Id = 1, Label = "Programmation avancée", FieldId = 1 },
                    new Lesson { Id = 2, Label = "Systèmes d'exploitation", FieldId = 1 },
                    new Lesson { Id = 3, Label = "Réseaux informatiques", FieldId = 1 },
                    new Lesson { Id = 4, Label = "Intelligence artificielle", FieldId = 1 },
                    new Lesson { Id = 5, Label = "Développement web", FieldId = 1 },

                    new Lesson { Id = 6, Label = "Gestion de la production", FieldId = 2 },
                    new Lesson { Id = 7, Label = "Optimisation industrielle", FieldId = 2 },
                    new Lesson { Id = 8, Label = "Conception et amélioration", FieldId = 2 },
                    new Lesson { Id = 9, Label = "Contrôle de la qualité", FieldId = 2 },
                    new Lesson { Id = 10, Label = "Chaîne d'approvisionnement", FieldId = 2 },

                    new Lesson { Id = 11, Label = "Architecture des réseaux", FieldId = 3 },
                    new Lesson { Id = 12, Label = "Protocoles de communication", FieldId = 3 },
                    new Lesson { Id = 13, Label = "Sécurité des réseaux", FieldId = 3 },
                    new Lesson { Id = 14, Label = "Télécommunications sans fil", FieldId = 3 },
                    new Lesson { Id = 15, Label = "Administration des systèmes réseau", FieldId = 3 },

                    new Lesson { Id = 16, Label = "Aérodynamique", FieldId = 4 },
                    new Lesson { Id = 17, Label = "Propulsion aérospatiale", FieldId = 4 },
                    new Lesson { Id = 18, Label = "Structures aéronautiques", FieldId = 4 },
                    new Lesson { Id = 19, Label = "Systèmes de navigation aérienne", FieldId = 4 },
                    new Lesson { Id = 20, Label = "Conception d'aéronefs", FieldId = 4 },

                    new Lesson { Id = 21, Label = "Thermodynamique appliquée", FieldId = 5 },
                    new Lesson { Id = 22, Label = "Génie chimique", FieldId = 5 },
                    new Lesson { Id = 23, Label = "Contrôle des procédés industriels", FieldId = 5 },
                    new Lesson { Id = 24, Label = "Gestion des installations de production", FieldId = 5 },
                    new Lesson { Id = 25, Label = "Séparation des fluides", FieldId = 5 }
                ];

            foreach (var lesson in lessons)
            {
                await dbService.AddLesson(lesson);
            }

            List<Student> students = GenerateStudents();


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
