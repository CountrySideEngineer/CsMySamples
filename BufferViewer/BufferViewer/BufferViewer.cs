using System;

namespace CSEng
{
	/// <summary>
	/// Main class of buffer viewer.
	/// </summary>
	public class BufferViewer
	{
		/// <summary>
		/// Show buffer in console line.
		/// </summary>
		/// <typeparam name="T">Data type of buffer</typeparam>
		/// <param name="buffer">Buffer data to show.</param>
		public void ShowBuff<T>(T[] buffer) where T : unmanaged
		{
			//Setup format.
			int charNumOfT = 0;
			unsafe
			{
				charNumOfT = sizeof(T) * 2;
			}
			string format = $"0x{{0:X{charNumOfT}}}";

			int rowHeaderLen = (buffer.Length / 16) + 1;
			int charNumOfRowHeader = rowHeaderLen.ToString().Length + 2;
			string rowHeaderFormat = $"{{0,{charNumOfRowHeader}}}";

			//Set column header.
			for (int index = 0; index < charNumOfRowHeader; index++)
			{
				Console.Write(" ");
			}
			Console.Write(" ");	//Set the white space into table top and column index.
			int charNumOfColHeader = charNumOfT + 2;
			string colHeaderFormat = $"{{0, {charNumOfColHeader}}}";
			for (int colNum = 0; colNum < 16; colNum++)
			{
				Console.Write(colHeaderFormat, colNum);
				Console.Write(" ");
			}
			Console.WriteLine();

			//Start writing buffer data.
			int colIndex = 0;
			int rowIndex = 0;
			foreach (T item in buffer)
			{
				if (0 == (colIndex) % 16)
				{
					if (0 != colIndex)
					{
						Console.WriteLine();

						colIndex = 0;
						rowIndex++;
					}
					Console.Write(rowHeaderFormat, rowIndex);
					Console.Write(" ");
				}

				var itemString = string.Format(format, item);
				Console.Write(itemString);
				Console.Write(" ");

				colIndex++;
			}
			Console.WriteLine();
		}
	}
}
