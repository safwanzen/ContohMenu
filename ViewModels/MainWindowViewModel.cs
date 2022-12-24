using ContohMenu.ViewModels.Menu;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace ContohMenu.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CurrentMenu = new MainMenuViewModel();

            App.TimerTick
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(time =>
                {
                    Time = DateTime.UtcNow.ToLongTimeString();
                });
        }

        [Reactive] public string Time { get; private set; }
        [Reactive] public ViewModelBase CurrentMenu { get; set; }
    }
}
