using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Wpf_MVVM.ViewModel
{
  public class RelayCommand<T> : ICommand
  {
    private readonly Predicate<T> _canExecute;
    private readonly Action<T> _execute;

    public RelayCommand(Predicate<T> canExecute, Action<T> execute)
    {
      _canExecute = canExecute;
      _execute = execute ?? throw new ArgumentNullException("execute");
    }

    public bool CanExecute(object parameter)
    {
      return _canExecute == null ? true : _canExecute((T)parameter);
    }

    public void Execute(object parameter)
    {
      _execute((T)parameter);
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }
  }
}
