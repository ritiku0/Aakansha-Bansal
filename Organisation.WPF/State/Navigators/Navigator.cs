using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Organisation.WPF.Commands;
using Organisation.WPF.ViewModels;
using Organisation.WPF.ViewModels.Factories;

namespace Organisation.WPF.State.Navigators
{
    public class Navigator : INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

    }
}
