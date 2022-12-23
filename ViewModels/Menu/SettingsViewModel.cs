using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContohMenu.ViewModels.Menu
{
    internal class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        {
            options = new string[] { "Back", "Set" };
            Update();
        }

        public override void Next()
        {
            base.Next();
            Console.WriteLine("Next button MainMenuViewModel pressed {0}", selectionIndex);
        }

        public override void Prev()
        {
            base.Prev();
            Console.WriteLine("Prev button MainMenuViewModel pressed {0}", selectionIndex);
        }

        public override void Enter()
        {
            base.Enter();
            Console.WriteLine("Enter button MainMenuViewModel pressed {0}", selectionIndex);
            if (selectionIndex == 0)
            {
                App.ChangeMenu(new MainMenuViewModel());
            }
        }
    }
}
