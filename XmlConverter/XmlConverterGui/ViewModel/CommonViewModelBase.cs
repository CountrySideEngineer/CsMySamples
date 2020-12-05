using CSEng.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEng.ViewModel
{
	public class CommonViewModelBase : ViewModelBase
	{
		#region Events
		/// <summary>
		/// Event handler to notify the convertion has finished successfully.
		/// </summary>
		public event EventHandler CommandOkEventHandler;

		/// <summary>
		/// Event handler to notify the converton has failed.
		/// </summary>
		public event EventHandler CommandNgEventHandler;
		#endregion

		#region Other methods and private properties in calling order
		public void RaiseCommandOkEvent(object sender, EventArgs e)
		{
			this.CommandOkEventHandler?.Invoke(this, e);
		}

		public void RaiseCommandNgEvent(object sender, EventArgs e)
		{
			this.CommandNgEventHandler?.Invoke(this, e);
		}
		#endregion
	}
}
