using ReactiveUI.Fody.Helpers;
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
            options = new string[] { "Back", "ADD", "SUBTRACT" };
            Init();
            Update();
        }

        public override void Enter()
        {
            base.Enter();
            Console.WriteLine("Enter button SettigsViewModel pressed {0}", selectionIndex);
            if (selectionIndex == 0)
            {
                App.ChangeMenu(new MainMenuViewModel());
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
