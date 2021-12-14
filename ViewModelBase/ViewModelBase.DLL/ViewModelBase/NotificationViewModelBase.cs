using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySideEngineer.ViewModel.Base
{
	/// <summary>
	/// Common base class for view model with notification event.
	/// This class inherits ViewModelBase, common base view model class.
	/// </summary>
	public class NotificationViewModelBase : ViewModelBase
	{
		/// <summary>
		/// Event handler to notify information of application.
		/// </summary>
		/// <param name="sender">Information sender</param>
		/// <param name="arg">Information data.</param>
		public delegate void NotifyInformationEventHandler(object sender, EventArgs arg);

		/// <summary>
		/// Notify OK information.
		/// </summary>
		public NotifyInformationEventHandler NotifyOkInformation;

		/// <summary>
		/// Notify NG information.
		/// </summary>
		public NotifyInformationEventHandler NotifyErrorInformation;

		/// <summary>
		/// Notify information.
		/// </summary>
		public NotifyInformationEventHandler NotifyInformation;
	}
}
