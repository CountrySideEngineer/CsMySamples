using System;
using System.ComponentModel.Design.Serialization;
using CSEng;

namespace BufferViewerSample
{
	class BufferViewerSample
	{
		static void Main(string[] args)
		{
			int buffSize = 300;
			var buffer = new ushort[buffSize];
			for (int index = 0; index < buffSize; index++)
			{
				buffer[index] = (ushort)index;
			}
			var viewr = new BufferViewer();
			viewr.ShowBuff(buffer);
		}
	}
}
