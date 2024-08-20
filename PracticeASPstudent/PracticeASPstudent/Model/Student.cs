using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PracticeASPstudent.Model
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Column]
        public string name { get; set; }
        [Column]
        public string email { get; set; }
        [Column]
        public string address { get; set; }
        [Column]
        public string mobileNumber { get; set; }
        [Column]
        public DateTime date { get; set; }
        [Column]
        public int fees { get; set; }
        [Column]
        public string status { get; set; }
    }
}
