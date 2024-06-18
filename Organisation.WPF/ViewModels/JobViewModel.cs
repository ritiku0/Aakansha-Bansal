using Organisation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.WPF.ViewModels
{
    public class JobViewModel : ViewModelBase
    {
        public ObservableCollection<Job> Jobs { get; }
        public JobViewModel()
        {
            Jobs = new ObservableCollection<Job>();
            AddJobs();
        }

        private void AddJobs()
        {
            Jobs.Add(new Job { JobName = "M1", MachineNumber = 11111111, JobLength = 111, JobStartDate = DateTime.Now, JobEndDate = DateTime.Now, TotalProduction = 100, ProductionSpeed = 10});
            Jobs.Add(new Job { JobName = "M2", MachineNumber = 22222222, JobLength = 222, JobStartDate = DateTime.Now, JobEndDate = DateTime.Now, TotalProduction = 200, ProductionSpeed = 20});
            Jobs.Add(new Job { JobName = "M3", MachineNumber = 33333333, JobLength = 333, JobStartDate = DateTime.Now, JobEndDate = DateTime.Now, TotalProduction = 300, ProductionSpeed = 30 });
            Jobs.Add(new Job { JobName = "M4", MachineNumber = 44444444, JobLength = 444, JobStartDate = DateTime.Now, JobEndDate = DateTime.Now, TotalProduction = 400, ProductionSpeed = 40});
        }
    }
}
