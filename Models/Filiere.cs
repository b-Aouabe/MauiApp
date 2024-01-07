using SQLite;

namespace MauiApp1.Models
{
    [Table("filiere")]
    public class Filiere
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Label { get; set; }
        public override string ToString()
        {
            return Label;
        }
    }
}
