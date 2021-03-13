using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class VisitHistory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Diagnosis { get; set; }

        public string Complaints { get; set; }

        [Required]
        public DateTime DateOfVisit { get; set; }

        public Guid SpecialistId { get; set; }
        public Specialist Specialist { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
