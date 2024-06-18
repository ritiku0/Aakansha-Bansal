using Organisation.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.WPF.ViewModels.Factories
{
    public interface IOrganisationViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
