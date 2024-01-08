using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.DbConfig;
using MauiApp1.Models;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels
{
    public partial class AddStudentVM: ObservableObject
    {
        public readonly LocalDbService dbService ;
        [ObservableProperty]
        string title="Add Student Page";

        public AddStudentVM(LocalDbService dbService)
        {
            this.dbService = dbService;
            SetFields();
        }

        async Task SetFields()
        {
            var allFields = await dbService.GetAllFields();
            foreach (var obj in allFields)
            {
                Filieres.Add(obj);
            }
        }

        [ObservableProperty]
        string firstName;

        [ObservableProperty]
        string lastName;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string identityNum;

        [ObservableProperty]
        string phoneNumber;

        [ObservableProperty]
        ObservableCollection<Filiere> filieres=[];

        [ObservableProperty]
        Filiere filiere;

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..",animate:true);
        }

        [RelayCommand]
        async Task Save()
        {
            string data = $"First Name ={FirstName} - LastName ={LastName} \nEmail ={Email} - IdentityNum ={IdentityNum}\n PhoneNumber = {PhoneNumber} -Filiere ={Filiere}";
            if (AreStringsSet(FirstName, LastName, Email, identityNum, phoneNumber) & Filiere != null)
            {
                var student = new Student()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    StudentNum = identityNum,
                    PhoneNumber = phoneNumber
                };
                await dbService.AddStudent(student);
                await Shell.Current.DisplayAlert("Success", "Student Added  Successfully !", "Ok");
                await Shell.Current.GoToAsync("..", animate: true);
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Some Field Are Not Set !", "Ok");
            }
            NumberOfStudents = (await dbService.GetAllStudents()).Count();
        }

        [ObservableProperty]
        int numberOfStudents;
        public static bool AreStringsSet(params string[] attributes)
        {
            foreach (var attribute in attributes)
            {
                if (!IsStringSet(attribute))
                {
                    return false; // If any attribute is not set, return false
                }
            }

            return true; // All attributes are set
        }

        public static bool IsStringSet(string attribute)
        {
            // You can modify this method based on your actual check
            return !string.IsNullOrEmpty(attribute);
        }
    }
}
