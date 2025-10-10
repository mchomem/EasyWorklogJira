using System.Windows.Input;

namespace EasyWorklogJira.WPFApp.Extensions;

public class CommandHandler : ICommand
{
    public Action _action;
    private Func<bool> _canExecute;

    /// <summary>
    /// Create command handler instace.
    /// </summary>
    /// <param name="action">Action to be executed by the command</param>
    /// <param name="canExecute">A boolean property to containg current permissions to execute the command</param>
    public CommandHandler(Action action, Func<bool> canExecute)
    {
        _action = action;
        _canExecute = canExecute;
    }

    /// <summary>
    /// Wires CanExecuteChanged event.
    /// </summary>
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    /// <summary>
    /// Forces checking if execute is allowed.
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public bool CanExecute(object parameter)
    {
        return _canExecute.Invoke();
    }

    public void Execute(object parameter)
    {
        _action();
    }
}
