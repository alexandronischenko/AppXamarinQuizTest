using SQLite;

namespace FirstApp.Models
{
    [Table("Courses")]
    public class Course
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Lecture { get; set; }
        public Poll Poll { get; set; }

        public override string ToString() => Title;
    }
}