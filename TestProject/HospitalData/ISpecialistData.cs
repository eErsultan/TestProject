using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.HospitalData
{
    public interface ISpecialistData
    {
        Specialist AddSpecialist(Specialist specialist);

        Specialist GetSpecialistById(Guid id);

        List<Specialist> GetSpecialists();

        void DeleteSpecialist(Guid id);

        Specialist UpdateSpecialistData(Guid id, Specialist specialist);
    }
}
