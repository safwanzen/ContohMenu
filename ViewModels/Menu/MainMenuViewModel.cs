using Avalonia.Controls;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ContohMenu.ViewModels.Menu
{
    internal class MainMenuViewModel : ViewModelBase
    {
        public MainMenuViewModel()
        {
            options = new string[] { "Settings", "Time" };
            Init();
            Update();
        }

        public override void Enter()
        {
            base.Enter();
            Console.WriteLine("Enter button MainMenuViewModel pressed. SelectionIndex -> {0}", selectionIndex);
            if (selectionIndex == 0)
            {
                App.ChangeMenu(new SettingsViewModel());
            } 
            else App.ChangeMenu(new TimeViewModel());

            Update();
        }
    }
}
