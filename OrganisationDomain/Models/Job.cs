using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Models
{
    public class Job : DomainObject
    {
        [Required]
        public string JobName { get; set; }
        public int JobLength { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime JobEndDate { get; set; }
        public int TotalProduction { get; set; }
        public int ProductionSpeed { get; set; }

        [Required]
        [StringLength(8)]
        public int MachineNumber { get; set; }

    }
   
}
