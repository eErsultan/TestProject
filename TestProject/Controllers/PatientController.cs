using Microsoft.AspNetCore.Mvc;
using TestProject.HospitalData;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientData _patientData;

        public PatientController(IPatientData patientData)
        {
            _patientData = patientData;
        }

        [HttpGet("getallpatient")]
        public IActionResult Get()
        {
            var patients = _patientData.GetPatients();
            if (patients == null)
            {
                return NotFound();
            }
            return Ok(patients);
        }


        [HttpDelete("deletepatient/{iin}")]
        public IActionResult DeletePatient(string iin)
        {
            if (_patientData.DeletePatient(iin))
            {
                return Ok();
            }
            return NotFound();
        }


        [HttpPost("addpatient")]
        public IActionResult AddPatient(Patient patient)
        {
            var newPatient = _patientData.AddPatient(patient);
            return Ok(newPatient);
        }


        [HttpGet("searchbyiin/{iin}")]
        public IActionResult SerachByIIN(string iin)
        {
            try
            {
                var patient = _patientData.SearchByIIN(iin);
                return Ok(patient);
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }


        [HttpPut("updatedatapatient/{iin}")]
        public IActionResult UpdateDataPatient(string iin, [FromBody]Patient newDataPatient)
        {
            try
            {
                var patient = _patientData.UpdateDataPatient(iin, newDataPatient);
                return Ok(patient);
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("addvisithistory")]
        public IActionResult AddVisitHistory(VisitHistory visit)
        {
            try
            {
                _patientData.VisitDoctor(visit);
                return Ok(visit);
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

    }
}
