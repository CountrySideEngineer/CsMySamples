using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressWindows_WinForm
{
	public class TableItem
	{
		/// <summary>
		/// The item is selected or not.
		/// </summary>
		public bool IsChecked { get; set; } = false;

		/// <summary>
		/// Item parameter, not index.
		/// </summary>
		public int Parameter { get; set; } = 0;

		/// <summary>
		/// Item name.
		/// </summary>
		public string Name { get; set; } = string.Empty;

		public bool Enabled { get; set; } = true;

		/// <summary>
		/// Default constructor.
		/// </summary>
		protected TableItem() { }

		public static IEnumerable<TableItem> Factory(int itemNum)
		{
			for (int index = 0; index < itemNum; index++)
			{
				byte[] byteName = new byte[32];
				ProgWork.GetName(index, byteName, 32);
				string name = System.Text.Encoding.ASCII.GetString(byteName).TrimEnd('\0');

				int nullIndex = name.IndexOf('\0');
				name = name.Substring(0, nullIndex);

				int parameter = 0;
				ProgWork.GetParameter(index, ref parameter);

				yield return new TableItem
				{
					Parameter = parameter,
					Name = name,
					Enabled = (0 == index % 2)
				};
			}
		}
	}
}
