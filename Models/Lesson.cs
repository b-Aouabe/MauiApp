using SQLite;

namespace MauiApp1.Models
{
    [Table("lesson")]
    public class Lesson
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Label { get; set; }
        public int FieldId { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
