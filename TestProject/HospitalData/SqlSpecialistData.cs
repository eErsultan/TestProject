using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.Models;

namespace TestProject.HospitalData
{
    public class SqlSpecialistData : ISpecialistData
    {
        private HospitalContext _hospitalContext;

        public SqlSpecialistData(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }

        // Добавить специалиста
        public Specialist AddSpecialist(Specialist specialist)
        {
            specialist.Id = Guid.NewGuid();
            _hospitalContext.Specialists.Add(specialist);
            _hospitalContext.SaveChanges();
            return specialist;
        }

        // Удалить специалиста
        public void DeleteSpecialist(Guid id)
        {
            var specialist = _hospitalContext.Specialists.FirstOrDefault(s => s.Id == id);
            if (specialist == null)
            {
                throw new Exception("Доктор не найден");
            }
            _hospitalContext.Specialists.Remove(specialist);
            _hospitalContext.SaveChanges();
        }

        // Получить специалиста по id
        public Specialist GetSpecialistById(Guid id)
        {
            var specialist = _hospitalContext.Specialists.FirstOrDefault(s => s.Id == id);
            if (specialist == null)
            {
                throw new Exception("Доктор не найден");
            }
            return specialist;
        }

        // Получить всех специалистов
        public List<Specialist> GetSpecialists()
        {
            var specialists = _hospitalContext.Specialists.ToList();
            return specialists;
        }

        // Обновить данные специалиста
        public Specialist UpdateSpecialistData(Guid id, Specialist newSpecialistData)
        {
            var specialist = _hospitalContext.Specialists.FirstOrDefault(s => s.Id == id);
            if (specialist == null)
            {
                throw new Exception("Доктор не найден");
            }
            specialist.FullName = newSpecialistData.FullName;
            specialist.Position = newSpecialistData.Position;
            _hospitalContext.Specialists.Update(specialist);
            _hospitalContext.SaveChanges();
            return specialist;
        }
    }
}
