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
	public class XmlConverterViewModel : CommonViewModelBase
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

		public XmlConverterViewModel()
		{
			this.SrcFilePath = string.Empty;
		}

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
				this.RaisePropertyChanged(nameof(CanConvert));
			}
		}

		/// <summary>
		/// Property of the convert can be executed or not.
		/// </summary>
		public bool CanConvert => this.CanConvertCommandExecute();
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
					this.convertCommand = new DelegateCommand(this.ConvertCommandExecute, this.CanConvertCommandExecute);
				}
				return this.convertCommand;
			}
		}

		/// <summary>
		/// Body of convert action.
		/// </summary>
		protected virtual void ConvertCommandExecute()
		{
			try
			{
				var converter = new XmlConverter.Model.XmlConverter();
				var convertResult = converter.Convert(this.srcFilePath);
				base.RaiseCommandOkEvent(this, null);
			}
			catch (Exception)
			{
				base.RaiseCommandNgEvent(this, null);
			}
		}

		/// <summary>
		/// Return whether a command to convert xml file can be executed or not.
		/// </summary>
		/// <returns>Returns true if the command can be executed, otherwise returns false.</returns>
		protected virtual bool CanConvertCommandExecute()
		{
			if ((string.IsNullOrEmpty(this.SrcFilePath)) || (string.IsNullOrWhiteSpace(this.SrcFilePath)))
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion
	}
}
