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
            _connection.CreateTableAsync<Teacher>();
            _connection.CreateTableAsync<Lesson>();
            _connection.CreateTableAsync<AbsenceHistory>();
            _connection.CreateTableAsync<Student>();
            _connection.CreateTableAsync<Filiere>();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _connection.Table<Student>().ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _connection.Table<Student>().Where(x => x.Id == id).FirstOrDefaultAsync();
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
    }
}
