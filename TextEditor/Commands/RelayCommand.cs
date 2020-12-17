using System;

namespace TextEditor.Commands
{
    internal class RelayCommand : BaseCommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Func<object, bool> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }
        public override bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
