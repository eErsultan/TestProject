using Microsoft.AspNetCore.Mvc;
using System;
using TestProject.HospitalData;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        private ISpecialistData _specialistData;

        public SpecialistController(ISpecialistData specialistData)
        {
            _specialistData = specialistData;
        }

        [HttpGet("getallspecialists")]
        public IActionResult GetSpecialists()
        {
            var specialists = _specialistData.GetSpecialists();
            return Ok(specialists);
        }


        [HttpPost("addspecialist")]
        public IActionResult AddSpecialist(Specialist specialist)
        {
            var newSpecialist = _specialistData.AddSpecialist(specialist);
            return Ok(newSpecialist);
        }


        [HttpDelete("deletespecialist/{id}")]
        public IActionResult DeleteSpecialist(Guid id)
        {
            try
            {
                _specialistData.DeleteSpecialist(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("getspecialistbyid/{id}")]
        public IActionResult GetSpecialistById(Guid id)
        {
            try
            {
                var specialist = _specialistData.GetSpecialistById(id);
                return Ok(specialist);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("updatespecialistdata/{id}")]
        public IActionResult UpdateSpecialistData(Guid id, Specialist newSpecialistData)
        {
            try
            {
                var specialist = _specialistData.UpdateSpecialistData(id, newSpecialistData);
                return Ok(specialist);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
