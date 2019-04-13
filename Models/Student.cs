using SchoolApi.Models;

namespace SchoolApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BithDate { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}