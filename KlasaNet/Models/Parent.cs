using System.ComponentModel.DataAnnotations;

namespace KlasaNet.Models
{
    public class Parent
    {
        [Key]
        public int IdParent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
