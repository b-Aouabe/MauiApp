using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.DbConfig;
using MauiApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels
{
    public partial class UpdateAbsenceVM : ObservableObject
    {
        public readonly LocalDbService dbService;

        public UpdateAbsenceVM(LocalDbService dbService)
        {
            this.dbService = dbService;
            SetFields();
            SetLessons();
        }

        [ObservableProperty]
        string title="Update Absence Page";

        Filiere filiere;
        public Filiere Filiere
        {
            get { return filiere; }
            set
            {
                if (filiere != value)
                {
                    filiere = value;
                    OnPropertyChanged(nameof(Filiere));

                    SetLessons();
                }
            }
        }


        [ObservableProperty]
        ObservableCollection<Student> students=[];

        [ObservableProperty]
        Lesson lesson;

        [ObservableProperty]
        ObservableCollection<Filiere> filieres = [];

        [ObservableProperty]
        ObservableCollection<Lesson> lessons=[];

        async Task SetFields()
        {
            var allFields = await dbService.GetAllFields();
            Filieres.Clear();
            foreach (var obj in allFields)
            {
                Filieres.Add(obj);
            }
        }

        public async Task SetLessons()
        {
            List<Lesson> allLessons;
            if (Filiere == null)
            {
                allLessons = await dbService.GetAllLessons();
            }
            else
            {
               allLessons = await dbService.GetLessonsByFieldId(Filiere.Id);
            }
            Lessons.Clear();
            foreach (var obj in allLessons)
            {
                Lessons.Add(obj);
            }
        }

        [RelayCommand]
        public async Task SetStudents()
        {
            List<Student> allStudents;
            if (Filiere == null)
            {
                allStudents = await dbService.GetAllStudents();
            }
            else
            {
                allStudents = await dbService.GetStudentsByFieldId(Filiere.Id);
            }
            Students.Clear();
            foreach (var obj in allStudents)
            {
                Students.Add(obj);
            }
        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..", animate: true);
        }

        [RelayCommand]
        async Task Save()
        {
            if (Lesson == null || Filiere == null)
            {
                await Shell.Current.DisplayAlert("Error", "Lession And Field Must Be Set !", "Ok");
            }
            else
            {
                await UpdateAbsences();
                await Shell.Current.GoToAsync("..",animate:true);
            }
        }


        async Task UpdateAbsences()
        {
            // Handle the Submit Changes button click
            var checkedStudents = Students.Where(student => student.IsChecked).ToList();
            var uncheckedStudents = Students.Where(student => !student.IsChecked).ToList();

            foreach (var student in checkedStudents)
            {
                var absenceTable = await dbService.GetAbsencesByLessonStudent(Lesson.Id,student.Id);
                absenceTable.Abscences++;
                await dbService.UpdateAbsenceHistory(absenceTable);
            }

            foreach (var student in uncheckedStudents)
            {
                var absenceTable = await dbService.GetAbsencesByLessonStudent(Lesson.Id, student.Id);
                absenceTable.Presences++;
                await dbService.UpdateAbsenceHistory(absenceTable);
            }

            await Shell.Current.DisplayAlert("Success","Absences Saved  Successfully !","Ok");
        }
    }
}
