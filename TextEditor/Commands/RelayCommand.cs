using System;
using System.Collections.Generic;
using System.Text;

namespace TextEditor
{
    class RelayCommand : BaseCommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Func<object, bool> CanExecute, Action<object> Execute)
        {
            canExecute = CanExecute;
            execute = Execute;
        }
        public override bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
