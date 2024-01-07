using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.DbConfig;
using MauiApp1.Models;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels
{
    public partial class AddStudentVM(LocalDbService dbService) : ObservableObject
    {
        public readonly LocalDbService dbService = dbService;
        [ObservableProperty]
        string title="Add Student Page";

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
        ObservableCollection<Filiere> filieres = [
            new Filiere { Id = 1,Label="fdffr" },
            new Filiere { Id = 2,Label="gtgtgt" }
            ];

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
            await Shell.Current.DisplayAlert("Message", data, "Ok");
        }
    }
}
