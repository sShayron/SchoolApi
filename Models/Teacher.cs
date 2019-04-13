using System.Collections.Generic;
using SchoolApi.Models;

namespace SchoolApi.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}