using System.ComponentModel.DataAnnotations;

namespace KlasaNet.Models
{
    public class Class
    {
        [Key]
        public int IdClass { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TeacherSubjectClass> TeacherSubjectClasses { get; set; }
    }
}
