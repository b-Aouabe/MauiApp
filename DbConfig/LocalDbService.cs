using MauiApp1.Models;
using SQLite;

namespace MauiApp1.DbConfig
{
    public class LocalDbService
    {
        private const string DB_NAME = "student_managment_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;
        
        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DB_NAME));
            _connection.CreateTableAsync<Lesson>();
            _connection.CreateTableAsync<AbsenceHistory>();
            _connection.CreateTableAsync<Student>();
            _connection.CreateTableAsync<Filiere>();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _connection.Table<Student>().ToListAsync();
        }
        public async Task<Student> GetStudentByFirstLastName(string first,string last)
        {
            return await _connection.Table<Student>().Where(x => x.FirstName.ToLower() == first.ToLower() && x.LastName.ToLower() == last.ToLower()).FirstOrDefaultAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await _connection.Table<Student>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Student>> GetStudentsByFieldId(int fieldId)
        {
            return await _connection.Table<Student>().Where(x => x.FieldId == fieldId).ToListAsync();
        }

        public async Task AddStudent(Student student)
        {
            await _connection.InsertAsync(student);
        }

        public async Task UpdateStudent(Student student)
        {
            await _connection.UpdateAsync(student); 
        }

        public async Task Delete(Student student)
        {
            await _connection.DeleteAsync(student);
        }

        //Lesson
        public async Task<Lesson> GetLessonById(int id)
        {
            return await _connection.Table<Lesson>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task AddLesson(Lesson lesson)
        {
            await _connection.InsertAsync(lesson);
        }
        public async Task<List<Lesson>> GetAllLessons()
        {
            return await _connection.Table<Lesson>().ToListAsync();
        }
        public async Task<List<Lesson>> GetLessonsByFieldId(int fieldId)
        {
            return await _connection.Table<Lesson>().Where(x=>x.FieldId==fieldId).ToListAsync();
        }
        //Filier
        public async Task AddField(Filiere filiere)
        {
            await _connection.InsertAsync(filiere);
        }
        public async Task<List<Filiere>> GetAllFields()
        {
            return await _connection.Table<Filiere>().ToListAsync();
        }

        //Absence History
        public async Task<List<AbsenceHistory>> GetAbsencesByLessonId(int LessonId)
        {
            return await _connection.Table<AbsenceHistory>().Where(x => x.LessonId == LessonId).ToListAsync();
        }
        public async Task<AbsenceHistory> GetAbsencesByLessonStudent(int LessonId,int StudentId)
        {
            AbsenceHistory absence;
            absence = await _connection.Table<AbsenceHistory>().Where(x => x.LessonId == LessonId && x.StudentId == StudentId).FirstOrDefaultAsync();
            if (absence == null)
            {
                absence = new AbsenceHistory()
                {
                    StudentId = StudentId,
                    LessonId = LessonId,
                    Presences = 0,
                    Abscences = 0
                };
                await AddAbsence(absence);
            }
            return absence;
        }
        public async Task UpdateAbsenceHistory(AbsenceHistory absenceHistory)
        {
            await _connection.UpdateAsync(absenceHistory);
        }
        public async Task AddAbsence(AbsenceHistory absence)
        {
            await _connection.InsertAsync(absence);
        }
    }
}
