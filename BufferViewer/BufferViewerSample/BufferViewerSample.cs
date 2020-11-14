using System;
using System.ComponentModel.Design.Serialization;
using CSEng;

namespace BufferViewerSample
{
	class BufferViewerSample
	{
		static void Main(string[] args)
		{
			int buffSize = 200;
			var buffer = new byte[buffSize];
			for (int index = 0; index < buffSize; index++)
			{
				buffer[index] = (byte)index;
			}
			var viewr = new BufferViewer();
			viewr.ShowBuff(buffer);
		}
	}
}
