using KlasaNet.Dto;
using KlasaNet.Models;
using Microsoft.EntityFrameworkCore;

namespace KlasaNet.Services
{
    public interface ISchoolServices
    {
        int CreateSchool(AddSchoolDto dto, IFormFile? file);
        void CreateDirectorAndSchool(AddSchoolDto dto, IFormFile? file);
    }

    public class SchoolServices : ISchoolServices
    {
        private readonly KlasaNetContext _context;

        public SchoolServices(KlasaNetContext context)
        {
            _context = context;
        }

        public int CreateSchool(AddSchoolDto dto, IFormFile? file)
        {
            var school = new School
            {
                Name = dto.Name,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
            };

            if (file != null && file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(stream);
                school.ImagePath = "/images/" + fileName;
            }

            _context.Schools.Add(school);
            _context.SaveChanges();

            return school.IdSchool;
        }

        public void CreateDirectorAndSchool(AddSchoolDto dto, IFormFile? file)
        {
            var director = new Director
            {
                FirstName = dto.Director.FirstName,
                LastName = dto.Director.LastName,
                Login = dto.Director.Login,
                Password = dto.Director.Password,
                Email = dto.Director.Email,
            };

            director.IdSchool = CreateSchool(dto,file);

            _context.Directors.Add(director);
            _context.SaveChanges();
        }

    }

}
