using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.HospitalData
{
    public class SqlPatientData : IPatientData
    {
        private HospitalContext _hospitalContext;

        public SqlPatientData(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }

        // Добавить пациента
        public Patient AddPatient(Patient patient)
        {
            patient.Id = Guid.NewGuid();
            _hospitalContext.Patients.Add(patient);
            _hospitalContext.SaveChanges();
            return patient;
        }

        // Удалить пациента
        public bool DeletePatient(string IIN)
        {
            var patient = _hospitalContext.Patients.FirstOrDefault(p => p.IIN == IIN);
            if (patient == null)
            {
                return false;
            }
            _hospitalContext.Patients.Remove(patient);
            _hospitalContext.SaveChanges();
            return true;
        }

        // Получить всех пациентов
        public List<Patient> GetPatients()
        {
            return _hospitalContext.Patients.ToList();
        }

        // Поиск пациента по ИИН
        public Patient SearchByIIN(string IIN)
        {
            var patient = _hospitalContext.Patients.FirstOrDefault(p => p.IIN == IIN);
            if (patient == null)
            {
                throw new Exception("Пациент не найден");
            }
            return patient;
        }

        // Обновить данные пациента
        public Patient UpdateDataPatient(string IIN, Patient newDataPatient)
        {
            var patient = _hospitalContext.Patients.FirstOrDefault(p => p.IIN == IIN);
            if (patient == null)
            {
                throw new Exception("Пациент не найден");
            }
            patient.IIN = newDataPatient.IIN;
            patient.FullName = newDataPatient.FullName;
            patient.Address = newDataPatient.Address;
            patient.PhoneNumber = newDataPatient.PhoneNumber;
            _hospitalContext.Patients.Update(patient);
            _hospitalContext.SaveChanges();
            return patient;
        }

        // Добавить посещение пациента 
        public void VisitDoctor(VisitHistory visit)
        {
            if (visit.PatientId == Guid.Empty || visit.SpecialistId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            visit.Id = Guid.NewGuid();
            visit.DateOfVisit = DateTime.Now;
            _hospitalContext.VisitHistories.Add(visit);
            _hospitalContext.SaveChanges();
        }
    }
}
