using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.HospitalData
{
    public interface IPatientData
    {
        Patient AddPatient(Patient patient);

        Patient SearchByIIN(string IIN);

        bool DeletePatient(string IIN);

        Patient UpdateDataPatient(string IIN, Patient patient);

        List<Patient> GetPatients();

        void VisitDoctor(VisitHistory visit);
    }
}
