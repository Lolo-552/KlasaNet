using System.ComponentModel.DataAnnotations;

namespace KlasaNet.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public int IdClass { get; set; }
        public int IdSchool { get; set; }
        public int IdHomeroomTeacher { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual School School { get; set; }
        public virtual Class Class { get; set; }
        public virtual Teacher HomeroomTeacher { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
    }
}
