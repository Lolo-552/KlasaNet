using System.ComponentModel.DataAnnotations;

namespace KlasaNet.Models
{
    public class Subject
    {
        [Key]
        public int IdSubject { get; set; }
        public int IdSchool { get; set; }
        public string Name { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<TeacherSubjectClass> TeacherSubjectClasses { get; set; }
    }
}
