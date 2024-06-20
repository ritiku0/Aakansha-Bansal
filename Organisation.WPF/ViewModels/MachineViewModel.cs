using Organisation.Domain.Models;
using Organisation.WPF.Commands;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.State.Navigators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Organisation.WPF.ViewModels
{
    public class MachineViewModel : ViewModelBase
    {
        private readonly IAuthenticator authenticator;
        private ObservableCollection<Machine> machines;
        private Machine machine;

        public ObservableCollection<Machine> Machines
        {
            get => machines;
            set
            {
                machines = value;
                OnPropertyChanged(nameof(Machines));
                OnPropertyChanged(nameof(CanUpdate));
            }
        }

        public Machine SelectedMachineItem
        {
            get => machine;
            set
            {
                machine = value;
                OnPropertyChanged(nameof(SelectedMachineItem));
                OnPropertyChanged(nameof(CanUpdate));
            }
        }

        public MachineViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            this.authenticator = authenticator;
            AddMachines();
            AddMachineCommand = new RenavigateCommand(registerRenavigator);
            UpdateMachineCommand = new UpdateMachineCommand(this, authenticator);
            DeleteMachineCommand = new DeleteMachineCommand(this, authenticator);


        }

        public bool CanUpdate(object param)
        {
            if (SelectedMachineItem!= null && SelectedMachineItem.MachineName != null)
            {
                return true;
            }

            return false;
        }
      

        public ICommand AddMachineCommand { get; }
        public ICommand UpdateMachineCommand { get; }
        public ICommand DeleteMachineCommand { get; }

        private async void AddMachines()
        {
            var machines = await authenticator.FetchMachines();
            Machines = new ObservableCollection<Machine>(machines);
        }

    }
}