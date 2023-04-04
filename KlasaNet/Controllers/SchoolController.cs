using KlasaNet.Data;
using KlasaNet.Dto;
using KlasaNet.Models;
using KlasaNet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KlasaNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {

        private readonly ISchoolServices _schoolServices;

        public SchoolController(ISchoolServices schoolServices)
        {
            _schoolServices = schoolServices;
        }
        // POST api/school
        [HttpPost]
        public ActionResult Create([FromForm] AddSchoolDto dto, IFormFile? file)
        {
            _schoolServices.CreateDirectorAndSchool(dto, file);
            return Ok();
        }
    }
}
