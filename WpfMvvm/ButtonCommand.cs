using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvm
{
    public class ButtonCommand : ICommand
    {
        private Action WhattoExecute;

        public ButtonCommand(Action What) // Point 1
        {
            WhattoExecute = What;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            WhattoExecute(); // Point 3
        }
    }
}
