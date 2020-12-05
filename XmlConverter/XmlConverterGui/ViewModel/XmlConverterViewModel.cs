using CSEng.Command;
using CSEng.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEng.XmlConverterGui.ViewModel
{
	/// <summary>
	/// View Model class of XmlConverter, GUI type.
	/// </summary>
	public class XmlConverterViewModel : ViewModelBase
	{
		#region Private fields and constants
		/// <summary>
		/// Field of path to source file path.
		/// </summary>
		protected string srcFilePath;

		/// <summary>
		/// Delegate command when the convert action is to be executed.
		/// </summary>
		private DelegateCommand convertCommand;
		#endregion

		#region Events
		/// <summary>
		/// Event handler to notify the convertion has finished successfully.
		/// </summary>
		public event EventHandler ConvertOkEventHandler;

		/// <summary>
		/// Event handler to notify the converton has failed.
		/// </summary>
		public event EventHandler ConvertNgEventHandler;
		#endregion

		#region Public properties
		/// <summary>
		/// Property of path to source file.
		/// </summary>
		public string SrcFilePath
		{
			get
			{
				return this.srcFilePath;
			}
			set
			{
				this.srcFilePath = value;
				this.RaisePropertyChanged(nameof(SrcFilePath));
			}
		}
		#endregion

		#region Other methods and private properties in calling order
		/// <summary>
		/// Property of command to execute convertion.
		/// </summary>
		public DelegateCommand ConvertCommand
		{
			get
			{
				if (null == this.convertCommand)
				{
					this.convertCommand = new DelegateCommand(this.ConvertCommandExecute);
				}
				return this.convertCommand;
			}
		}

		/// <summary>
		/// Body of convert action.
		/// </summary>
		protected virtual void ConvertCommandExecute()
		{
		}
		#endregion
	}
}
