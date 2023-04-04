using System.ComponentModel.DataAnnotations;

namespace KlasaNet.Models
{

    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }
        public int IdSchool { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TeacherSubjectClass> TeacherSubjectClasses { get; set; }
    }

}
