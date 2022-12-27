using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;

namespace ContohMenu.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected int selectionIndex = 0;
        protected string[] options;

        virtual protected void Init()
        {
            if (options != null)
                OptionList = new ObservableCollection<string>(options);
        }

        virtual public void Next() 
        {
            if (options.Length > 0)
            {
                selectionIndex++;
                if (selectionIndex > options.Length - 1)
                    selectionIndex = 0;
                Update();
            }
            Console.WriteLine("base Next button pressed"); 
        }

        virtual public void Prev()
        {
            if (options.Length > 0)
            {
                selectionIndex--;
                if (selectionIndex < 0)
                    selectionIndex = options.Length - 1;
                Update();
            }
            Console.WriteLine("base Prev button pressed");
        }

        virtual public void Enter()
        {
            Console.WriteLine("base Enter button pressed");
        }
        
        // for updating string being shown only
        virtual protected void Update()
        {
            Options = "";

            for (int i = 0; i < options.Length; i++)
            {
                string str = options[i];
                if (i == selectionIndex)
                {
                    if (str.Contains('\n'))
                    {
                        Options += $" >" + str.Replace("\n", "") + "<\n";
                    }
                    else
                        Options += " >" + str + "<";
                }
                else
                    Options += " " + str;
            }

            for (int i = 0; i < OptionList.Count; i++)
            {
                if (i == selectionIndex)
                {
                    OptionList[i] = ">" + options[i] + "<";
                }
                else OptionList[i] = options[i];
            }

        }

        [Reactive] public string Options { get; protected set; } = "";
        [Reactive] public ObservableCollection<string> OptionList { get; protected set; } = new();
    }
}
