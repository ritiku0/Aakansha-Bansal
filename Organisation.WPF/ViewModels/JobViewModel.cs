using Organisation.Domain.Models;
using Organisation.WPF.Commands;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Organisation.WPF.ViewModels
{
    
    public class JobViewModel : ViewModelBase
    {
        private readonly IAuthenticator authenticator;
        private ObservableCollection<Job> jobs;
        private Job job;

        public ObservableCollection<Job> Jobs
        {
            get => jobs;
            set
            {
                jobs = value;
                OnPropertyChanged(nameof(Jobs));
                OnPropertyChanged(nameof(CanUpdate));
            }
        }

        public Job SelectedJobItem
        {
            get => job;
            set
            {
                job = value;
                OnPropertyChanged(nameof(SelectedJobItem));
                OnPropertyChanged(nameof(CanUpdate));
            }
        }

        public JobViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            this.authenticator = authenticator;
            AddJobs();
            AddJobCommand = new RenavigateCommand(registerRenavigator);
            UpdateJobCommand = new UpdateJobCommand(this, authenticator);
            DeleteJobCommand = new DeleteJobCommand(this, authenticator);
        }

        public bool CanUpdate(object param)
        {
            if (SelectedJobItem != null && SelectedJobItem.JobName != null)
            {
                return true;
            }

            return false;
        }


        public ICommand AddJobCommand { get; }
        public ICommand UpdateJobCommand { get; }
        public ICommand DeleteJobCommand { get; }

        private async void AddJobs()
        {
            var machines = await authenticator.FetchJobs();
            Jobs = new ObservableCollection<Job>(machines);
        }

    }
}
