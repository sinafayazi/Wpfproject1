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
        public RelayCommand(Action<object> ExecuteAction,
            Func<object, bool> CanExecuteAction)
        {
            this.CanExecuteAction = CanExecuteAction;
            this.ExecuteAction = ExecuteAction;
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
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }


    }
}
