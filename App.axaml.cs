using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ContohMenu.ViewModels;
using ContohMenu.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ContohMenu
{
    public partial class App : Application
    {
        private static MainWindowViewModel MainVM;

        public static int Counter = 0;
        public static IConnectableObservable<long> TimerTick;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            TimerTick = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1)).Publish();
            TimerTick.Connect();

            UtcTime = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1))
                .Select(_ => DateTime.UtcNow.ToLongTimeString())
                .Publish();
            UtcTime.Connect();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = MainVM = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        public static void ChangeMenu(ViewModelBase vm)
        {
            MainVM.CurrentMenu = vm;
        }

        public static IConnectableObservable<string> UtcTime { get; set; }
    }
}
