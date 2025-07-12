using BeatHealth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeatHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;
    public    DoctorController(DoctorService doctorService) { _doctorService = doctorService; }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {

            List<Doctor> r =[];
            r=await _doctorService.Get(id);
            return Ok(r);

        }


    }
}
