using Avalonia.Controls;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContohMenu.ViewModels.Menu
{
    internal class MainMenuViewModel : ViewModelBase
    {
        public MainMenuViewModel()
        {
            options = new string[] { "Settings", "ADD", "SUBTRACT" };
            Update();
        }

        public override void Next()
        {
            Console.WriteLine("Next button MainMenuViewModel pressed. SelectionIndex -> {0}", selectionIndex);
        }

        public override void Prev()
        {
            Console.WriteLine("Prev button MainMenuViewModel pressed. SelectionIndex -> {0}", selectionIndex);
        }

        public override void Enter()
        {
            base.Enter();
            Console.WriteLine("Enter button MainMenuViewModel pressed. SelectionIndex -> {0}", selectionIndex);
            if (selectionIndex == 0)
            {
                App.MainVM.CurrentMenu = new SettingsViewModel();
            }
            else if (selectionIndex == 1)
            {
                App.Counter++;
            }
            else if (selectionIndex == 2)
            {
                App.Counter--;
            }
            Update();
        }

        protected override void Update()
        {
            base.Update();
            Number = App.Counter.ToString();
        }

        [Reactive] public string Number { get; private set; }
    }
}
