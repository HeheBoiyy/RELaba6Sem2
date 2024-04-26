using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RELaba5Sem2.src
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }
    }
}
