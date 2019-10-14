using System;
using System.Windows.Input;

namespace PasswordGenerator.WPF {
    public class Command : ICommand {
        public Command(Action action) : this(_ => action()) { }
        public Command(Action<object> action) {
            this.action = action;
        }

        readonly Action<object> action;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            action?.Invoke(parameter);
        }
    }
}