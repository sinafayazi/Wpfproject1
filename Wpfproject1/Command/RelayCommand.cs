using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpfproject1.Command
{
    public class RelayCommand : ICommand
    {
        Action<object> ExecuteAction;
        Func<object, bool> CanExecuteAction;
        bool CanExecuteCache;

        public RelayCommand(Action<object> ExecuteAction, Func<object, bool> CanExecuteAction, bool CanExecuteCache)
        {
            this.CanExecuteAction = CanExecuteAction;
            this.ExecuteAction = ExecuteAction;
            this.CanExecuteCache = CanExecuteCache;
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteAction == null)
            {
                return true;

            }
            else
            {
                return CanExecuteAction(parameter);
            }  
        }

        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
