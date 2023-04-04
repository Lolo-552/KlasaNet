namespace KlasaNet.Dto
{
    public class AddSchoolDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DirectorDto Director { get; set; }
    }
}
