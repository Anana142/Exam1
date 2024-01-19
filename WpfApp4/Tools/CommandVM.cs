using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp4.Tools
{
    internal class CommandVM : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> func;

        public CommandVM(Action action, Func<bool> func)
        {
            this.action = action;
            this.func = func;
        }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        public bool CanExecute(object? parameter)
        {
            return func();
        }

        public void Execute(object? parameter)
        {
            action();
        }
    }
}
