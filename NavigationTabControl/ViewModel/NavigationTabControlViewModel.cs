using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NavigationTabControl.Command;

namespace NavigationTabControl.ViewModel
{
	public class NavigationTabControlViewModel : ViewModelBase
	{
		#region Private fields and constants.
		private DelegateCommand<string> _ChangeCurrentTabCommand;

		protected int _CurrentTabIndex;
		#endregion

		#region Public properties
		/// <summary>
		/// Current selected tab index.
		/// </summary>
		public int CurrentTabIndex
		{
			get
			{
				return this._CurrentTabIndex;
			}
			set
			{
				this._CurrentTabIndex = value;
				this.RaisePropertyChanged(nameof(CurrentTabIndex));
			}
		}
		#endregion

		#region Constructors and the finalizer
		public NavigationTabControlViewModel()
		{
			this.CurrentTabIndex = 0;
			this._ChangeCurrentTabCommand = null;
		}
		#endregion

		#region Other methods and private properties in calling order
		/// <summary>
		/// Command to change tab index.
		/// </summary>
		public DelegateCommand<string> ChangeCurrentTabCommand
		{
			get
			{
				if (null == this._ChangeCurrentTabCommand)
				{
					this._ChangeCurrentTabCommand = 
						new DelegateCommand<string>(
							this.ChangeCurrentTabCommandExecute, this.CanChangeCurrentTabCommandExecute); ;
				}
				return this._ChangeCurrentTabCommand;
			}
		}

		/// <summary>
		/// Execute current tab change command.
		/// </summary>
		/// <param name="tabIndex">Tab index to show.</param>
		public void ChangeCurrentTabCommandExecute(string tabIndex)
		{
			try
			{
				int tabIndexInNum = Convert.ToInt32(tabIndex);
				this.CurrentTabIndex = tabIndexInNum;
			}
			catch (Exception ex)
			when ((ex is FormatException) || (ex is OverflowException))
			{
				Debug.WriteLine(ex.Message);
			}
		}
		public bool CanChangeCurrentTabCommandExecute(object arg) { return true; }
		#endregion
	}
}
