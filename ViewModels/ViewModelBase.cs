using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;

namespace ContohMenu.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected int selectionIndex = 0;
        protected string[] options;

        virtual public void Next() 
        {
            if (options.Length > 0)
            {
                selectionIndex++;
                if (selectionIndex > options.Length - 1)
                    selectionIndex = 0;
                Update();
            }
            Console.WriteLine("Next button pressed"); 
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
            Console.WriteLine("Prev button pressed");
        }

        virtual public void Enter()
        {
            Console.WriteLine("Enter button pressed");
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
        }

        [Reactive] public string Options { get; protected set; } = "";
    }
}
