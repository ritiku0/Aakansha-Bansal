using Organisation.WPF.Commands;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Organisation.WPF.ViewModels
{    
    public class AddNewJobViewModel : ViewModelBase
    {
        private string _jobName;
        public string JobName
        {
            get
            {
                return _jobName;
            }
            set
            {
                _jobName = value;
                OnPropertyChanged(nameof(JobName));
                OnPropertyChanged(nameof(CanRegister));
            }
        }
       

        private int _machineNumber;
        public int MachineNumber
        {
            get
            {
                return _machineNumber;
            }
            set
            {
                _machineNumber = value;
                OnPropertyChanged(nameof(MachineNumber));
                OnPropertyChanged(nameof(CanRegister));
            }
        }
        private int _jobLength;
        public int JobLength
        {
            get
            {
                return _jobLength;
            }
            set
            {
                _jobLength = value;
                OnPropertyChanged(nameof(JobLength));
                OnPropertyChanged(nameof(CanRegister));
            }
        }


        private DateTime _jobStartDate;
        public DateTime JobStartDate
        {
            get
            {
                return _jobStartDate;
            }
            set
            {
                _jobStartDate = value;
                OnPropertyChanged(nameof(JobStartDate));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private DateTime _jobEndDate;
        public DateTime JobEndDate
        {
            get
            {
                return _jobEndDate;
            }
            set
            {
                _jobStartDate = value;
                OnPropertyChanged(nameof(JobEndDate));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private int _totalProduction;
        public int TotalProduction
        {
            get
            {
                return _totalProduction;
            }
            set
            {
                _totalProduction = value;
                OnPropertyChanged(nameof(TotalProduction));
                OnPropertyChanged(nameof(CanRegister));
            }
        }
        
        public bool CanRegister => !string.IsNullOrEmpty(JobName) &&
            !string.IsNullOrEmpty(MachineNumber.ToString()) &&
            !string.IsNullOrEmpty(TotalProduction.ToString()) &&
            !string.IsNullOrEmpty(JobStartDate.ToString()) && !string.IsNullOrEmpty(JobEndDate.ToString());

        public ICommand AddJobCommand { get; }

        public AddNewJobViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            AddJobCommand = new AddNewJobCommand(this, authenticator, registerRenavigator);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
