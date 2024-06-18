using Organisation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.WPF.ViewModels
{
    public class MachineViewModel : ViewModelBase
    {
        public ObservableCollection<Machine> Machines { get; }
        public MachineViewModel()
        {
            Machines = new ObservableCollection<Machine>();
            AddMachines();
        }

        private void AddMachines()
        {
            Machines.Add(new Machine { MachineName = "M1", MachineNumber = 11111111, MachineImage = "M1.png", ManufacturingDate = DateTime.Now, ProductionSpeed = 100 });
            Machines.Add(new Machine { MachineName = "M2", MachineNumber = 22222222, MachineImage = "M2.png", ManufacturingDate = DateTime.Now, ProductionSpeed = 200 });
            Machines.Add(new Machine { MachineName = "M3", MachineNumber = 33333333, MachineImage = "M3.png", ManufacturingDate = DateTime.Now, ProductionSpeed = 300 });
            Machines.Add(new Machine { MachineName = "M4", MachineNumber = 44444444, MachineImage = "M4.png", ManufacturingDate = DateTime.Now, ProductionSpeed = 400 });
        }
    }
   
}
