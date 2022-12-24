using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContohMenu.ViewModels.Menu
{
    internal class TimeViewModel : ViewModelBase, IDisposable
    {
        IDisposable disposable;

        public TimeViewModel()
        {
            options = new string[] { "Back" };
            Update();

            Time = DateTime.UtcNow.ToLongTimeString();

            disposable = App.TimerTick
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(time =>
                {
                    Time = DateTime.UtcNow.ToLongTimeString();
                });
        }

        public override void Enter()
        {
            App.ChangeMenu(new MainMenuViewModel());
            disposable.Dispose();
        }

        public void Dispose()
        {
            disposable?.Dispose();
        }

        [Reactive] public string Time { get; set; }
    }
}
