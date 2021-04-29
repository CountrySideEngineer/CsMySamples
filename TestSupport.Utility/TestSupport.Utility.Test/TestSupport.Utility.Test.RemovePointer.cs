using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CSEngineer.TestSupport.Utility;

namespace TestSupport.Utility.Test
{
	[TestClass]
	public class RemovePointer_Test
	{
		[TestMethod]
		public void RemovePointer_Test_001()
		{
			string dataType = "data";

			string removedDataType = Util.RemovePointer(dataType);

			Assert.AreEqual("data", removedDataType);
		}

		[TestMethod]
		public void RemovePointer_Test_002()
		{
			string dataType = "data*";

			string removedDataType = Util.RemovePointer(dataType);

			Assert.AreEqual("data", removedDataType);
		}

		[TestMethod]
		public void RemovePointer_Test_003()
		{
			string dataType = "data**";

			string removedDataType = Util.RemovePointer(dataType);

			Assert.AreEqual("data", removedDataType);
		}

		[TestMethod]
		public void RemovePointer_Test_004()
		{
			string dataType = "*data";

			string removedDataType = Util.RemovePointer(dataType);

			Assert.AreEqual("*data", removedDataType);
		}
	}
}
