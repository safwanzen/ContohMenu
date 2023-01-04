using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContohMenu.ViewModels.Menu
{
    internal class ButtonHoldViewModel : MenuViewModelBase
    {
        public ButtonHoldViewModel() { }

        [Reactive] public string Text { get; set; }
    }
}
