using BeatHealth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BeatHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;
    public    DoctorController(DoctorService doctorService) { _doctorService = doctorService; }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetDoctor(int id=0)
        {
                List<Doctor> r = await _doctorService.Get(id);
                if (id==0&&r.Count==1)return Ok(r.First());
                return Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] Doctor d) 
        {
            int id= await _doctorService.Post(d);
            if (id == 0) return StatusCode(400,"Could not create a new doctor");
            return Ok(d);
               
        }
    }
}
