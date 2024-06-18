using Organisation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Organisation.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        Profile,
        MachineView,
        JobView
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
