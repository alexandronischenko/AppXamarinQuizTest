using System.Collections.ObjectModel;
using System.Globalization;

namespace FirstApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Lecture { get; set; }
        public Poll Poll { get; set; }
    }
}