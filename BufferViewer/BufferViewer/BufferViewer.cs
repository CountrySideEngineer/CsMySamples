using System;

namespace CSEng
{
	/// <summary>
	/// Main class of buffer viewer.
	/// </summary>
	public class BufferViewer
	{
		#region Constructor and finalizer.
		/// <summary>
		/// Default constructor.
		/// </summary>
		public BufferViewer()
		{
			this.dataSize = 0;
			this.dataNumPerLine = 16;

			this.tableContentFormat = string.Empty;
			this.colHeaderFormat = string.Empty;
			this.rowHeaderFormat = string.Empty;
			this.tableTopContent = string.Empty;
		}
		#endregion

		#region protected properties
		/// <summary>
		/// Size of data type the buffer to show in console.
		/// </summary>
		protected int dataSize;

		/// <summary>
		/// The number 
		/// </summary>
		protected int dataNumPerLine;

		/// <summary>
		/// Format for content of table.
		/// </summary>
		protected string tableContentFormat;

		/// <summary>
		/// Format for column header.
		/// </summary>
		protected string colHeaderFormat;

		/// <summary>
		/// Foramt for row header.
		/// </summary>
		protected string rowHeaderFormat;

		/// <summary>
		/// Content of table top, cell of left and top of table.
		/// </summary>
		protected string tableTopContent;
		#endregion

		#region Public mehtods
		/// <summary>
		/// Show buffer in console line.
		/// </summary>
		/// <typeparam name="T">Data type of buffer</typeparam>
		/// <param name="buffer">Buffer data to show.</param>
		public void ShowBuff<T>(T[] buffer) where T : unmanaged
		{
			//Setup format.
			unsafe
			{
				this.dataSize = sizeof(T) * 2;
			}
			this.SetupParameters(buffer);
			this.ShowTableHeader();
			this.ShowTableContent(buffer);
		}
		#endregion

		#region private or protected method.
		/// <summary>
		/// Setup parameters to be used when creating the buffer data.
		/// </summary>
		/// <typeparam name="T">Data type of buffer data.</typeparam>
		/// <param name="buffer">Data array to show in console.</param>
		protected void SetupParameters<T>(T[] buffer)
		{
			this.tableContentFormat = $" 0x{{0:X{this.dataSize}}}";

			int charNumOfColNumber = this.dataSize + 2;
			this.colHeaderFormat = $" {{0, {charNumOfColNumber}}}";

			int rowHeaderLen = (buffer.Length / this.dataNumPerLine) + 1;
			int charNumOfRowNumber = rowHeaderLen.ToString().Length;
			this.rowHeaderFormat = $" {{0, {charNumOfRowNumber}}}";
			this.tableTopContent = string.Empty;
			for (int index = 0; index < (charNumOfRowNumber + 1); index++)
			{
				this.tableTopContent += " ";
			}
		}

		/// <summary>
		/// Show table header, column header.
		/// </summary>
		protected void ShowTableHeader()
		{
			Console.Write(this.tableTopContent);
			for (int index = 0; index < this.dataNumPerLine; index++)
			{
				Console.Write(this.colHeaderFormat, index);
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Show table content.
		/// Row header and buffer data in table.
		/// </summary>
		/// <typeparam name="T">Data type of buffer.</typeparam>
		/// <param name="buffer">Data to show in the table.</param>
		protected void ShowTableContent<T>(T[] buffer)
		{

			int colIndex = 0;
			int rowIndex = 0;
			foreach (T bufferItem in buffer)
			{
				if (0 == (colIndex % dataNumPerLine))
				{
					if (0 != colIndex)
					{
						Console.WriteLine();

						colIndex = 0;
						rowIndex++;
					}
					Console.Write(this.rowHeaderFormat, rowIndex);
				}
				Console.Write(this.tableContentFormat, bufferItem);
				colIndex++;
			}
			Console.WriteLine();
		}
		#endregion

	}
}
