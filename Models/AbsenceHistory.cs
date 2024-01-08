using SQLite;

namespace MauiApp1.Models
{
    [Table("absence_state")]
    public class AbsenceHistory
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public int Abscences { get; set; }
        public int Presences { get; set; }
    }
}
