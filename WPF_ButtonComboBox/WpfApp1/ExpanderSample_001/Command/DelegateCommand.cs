using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpanderSample_001.Command
{
	public class DelegateCommand : ICommand
	{
		/// <summary>
		/// Field which will be executed when the command is called.
		/// </summary>
		protected Action _execute;

		/// <summary>
		/// Field which represents whether the command can executed or not.
		/// </summary>
		protected Func<bool> _canExecute;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="execute">Action to execute.</param>
		public DelegateCommand(Action execute) : this(execute, () => true) { }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="execute">Action to execute.</param>
		/// <param name="canExecute">Function which returns the command can execute or not.</param>
		public DelegateCommand(Action execute, Func<bool> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		/// <summary>
		/// Event the status the command can execute.
		/// </summary>
		public event EventHandler? CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		/// <summary>
		/// Returns status whether the command can execute or not.
		/// </summary>
		/// <param name="parameter">Not will be used.</param>
		/// <returns>
		/// Returns true when the command can execute, otherwise returns false.
		/// </returns>
		public bool CanExecute(object? parameter)
		{
			return _canExecute();
		}

		/// <summary>
		/// Execute command.
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object? parameter)
		{
			_execute();
		}

	}
}
