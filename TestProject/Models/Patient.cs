using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(12)]
        [MaxLength(12)]
        public string IIN { get; set; }

        [Required]
        [MinLength(3)]
        public string FullName { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Address { get; set; }

        [Required]
        [MinLength(11)]
        public string PhoneNumber { get; set; }

        public List<VisitHistory> VisitHistories { get; set; }
    }
}
