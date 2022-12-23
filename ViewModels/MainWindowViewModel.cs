using ContohMenu.ViewModels.Menu;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContohMenu.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CurrentMenu = new MainMenuViewModel();
        }

        [Reactive] public ViewModelBase CurrentMenu { get; set; }
    }
}
