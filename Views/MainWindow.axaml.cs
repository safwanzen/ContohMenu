using Avalonia.Controls;
using Avalonia.Threading;
using ContohMenu.ViewModels;
using System;

namespace ContohMenu.Views
{
    public partial class MainWindow : Window
    {
        Button _holdButton;
        MainWindowViewModel vm;
        DispatcherTimer Timer;
        int Tickcount = 0;

        public MainWindow()
        {
            InitializeComponent();

            Timer = new DispatcherTimer(priority: DispatcherPriority.Normal);
            Timer.Interval = TimeSpan.FromMilliseconds(1000.0);

            DataContextChanged += (s, e) =>
            {
                if (vm != null) return;
                vm = DataContext as MainWindowViewModel;
            };

            _holdButton = this.FindControl<Button>("HoldButton");
            _holdButton.AddHandler(PointerReleasedEvent, _holdButton_PointerReleased, handledEventsToo: true);
            _holdButton.AddHandler(PointerPressedEvent, _holdButton_PointerPressed, handledEventsToo: true);
        }

        private void _holdButton_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                vm.IsHold = true;
                //Console.WriteLine("pressed");
                //Timer.Tick += IncrementTick;
                //Timer.Start();
            }
        }

        private void _holdButton_PointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs e)
        {
            if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                vm.IsHold = false;
                //Console.WriteLine("released");
                //ResetTimer();
            }
        }

        private void IncrementTick(object? o, EventArgs e)        
        {
            Console.WriteLine(Tickcount);
            Tickcount++;
            if (Tickcount >= 4)
            {
                ResetTimer();
            }
        }
        

        private void ResetTimer()
        {
            Console.WriteLine(Tickcount);
            Timer.Stop();
            Tickcount = 0;
            Timer.Tick -= IncrementTick;
        }
    }
}
