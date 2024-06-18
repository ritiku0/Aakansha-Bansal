using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Models
{
    public class Machine : DomainObject
    {
        [Required]
        public string MachineName { get; set; }

        [Required]
        [StringLength(8)]
        public int MachineNumber { get; set; }
        public string MachineImage { get; set; }
        public int ProductionSpeed { get; set; }
        public DateTime ManufacturingDate { get; set; }
    }
}
