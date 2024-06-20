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
    public class AddNewMachineViewModel : ViewModelBase
    {
        private string _machineName;
        public string MachineName
        {
            get
            {
                return _machineName;
            }
            set
            {
                _machineName = value;
                OnPropertyChanged(nameof(MachineName));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _machineImage;
        public string MachineImage
        {
            get
            {
                return _machineImage;
            }
            set
            {
                _machineImage = value;
                OnPropertyChanged(nameof(MachineImage));
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
        private int _productionSpeed;
        public int ProductionSpeed
        {
            get
            {
                return _productionSpeed;
            }
            set
            {
                _productionSpeed = value;
                OnPropertyChanged(nameof(ProductionSpeed));
                OnPropertyChanged(nameof(CanRegister));
            }
        }


        private DateTime _mfgDate;
        public DateTime MfgDate
        {
            get
            {
                return _mfgDate;
            }
            set
            {
                _mfgDate = value;
                OnPropertyChanged(nameof(MfgDate));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        

        public bool CanRegister => !string.IsNullOrEmpty(MachineName) &&
            !string.IsNullOrEmpty(MachineNumber.ToString()) &&
            !string.IsNullOrEmpty(ProductionSpeed.ToString()) &&
            !string.IsNullOrEmpty(MfgDate.ToString());

        public ICommand AddMachineCommand { get; }              

        public AddNewMachineViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            AddMachineCommand = new AddNewMachineCommand(this, authenticator, registerRenavigator);          
        }

        public override void Dispose()
        {           
            base.Dispose();
        }
    }
}
