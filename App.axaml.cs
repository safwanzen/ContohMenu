using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ContohMenu.ViewModels;
using ContohMenu.Views;

namespace ContohMenu
{
    public partial class App : Application
    {
        private static MainWindowViewModel MainVM;

        public static int Counter = 0;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
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
    }
}
