using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Specialist
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        public string Position { get; set; }

        public List<VisitHistory> VisitHistories { get; set; }
    }
}
