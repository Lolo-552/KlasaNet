using System.ComponentModel.DataAnnotations;

namespace KlasaNet.Models
{
    public class TeacherSubjectClass
    {
        [Key]
        public int IdTeacherSubjectClass { get; set; }
        public int IdTeacher { get; set; }
        public int IdClass { get; set; }
        public int IdSubject { get; set; }
        public int IdSchool { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual School School { get; set; }
    }
}
