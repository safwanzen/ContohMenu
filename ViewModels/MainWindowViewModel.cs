using ContohMenu.ViewModels.Menu;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContohMenu.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        bool launched = false;

        public MainWindowViewModel()
        {
            CurrentMenu = new MainMenuViewModel();

            //App.TimerTick
            //    .ObserveOn(RxApp.MainThreadScheduler)
            //    .Subscribe(time =>
            //    {
            //        Time = DateTime.UtcNow.ToLongTimeString();
            //    });

            App.UtcTime.ToPropertyEx(this, x => x.Time);

            var timerobs = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler);
            var disp = Disposable.Empty;

            MenuViewModelBase prevvm = null;

            this.WhenAnyValue(x => x.IsHold)
                .Skip(1)
                .Subscribe(holding =>
                {
                    if (holding && launched)
                    {
                        launched = false;
                        CurrentMenu = new MainMenuViewModel();
                    }
                    else if (!launched)
                    {
                        if (holding)
                        {
                            Console.WriteLine("Button pressed");
                            prevvm = CurrentMenu;
                            var buttonviewmodel = new ButtonHoldViewModel();
                            CurrentMenu = buttonviewmodel;
                            int time = 6;
                            disp = timerobs.Subscribe(x =>
                            {
                                time--;
                                buttonviewmodel.Text = $"Launching rocket in {time}";
                                Console.WriteLine(time);
                                if (time <= 0)
                                {
                                    Console.WriteLine("Time up");
                                    launched = true;
                                    CurrentMenu = new RocketLaunchedViewModel();
                                    disp.Dispose();
                                }
                            });
                        }
                        else
                        {
                            if (prevvm != null)
                            {
                                CurrentMenu = prevvm;
                            }
                            disp.Dispose();
                            Console.WriteLine("Button released");
                        }
                    }
                });
        }

        [ObservableAsProperty] public string Time { get; private set; }
        [Reactive] public MenuViewModelBase CurrentMenu { get; set; }
        [Reactive] public bool IsHold { get; set; }
    }
}
