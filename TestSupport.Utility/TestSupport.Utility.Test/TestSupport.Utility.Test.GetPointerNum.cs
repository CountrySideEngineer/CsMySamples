using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CSEngineer.TestSupport.Utility;

namespace TestSupport.Utility.Test
{
	[TestClass]
	public class GetPointerNum_Test
	{
		[TestMethod]
		public void GetPointerNum_Test_001()
		{
			string dataType = "data";

			int pointerNum = Util.GetPointerNum(dataType);

			Assert.AreEqual(0, pointerNum);
		}

		[TestMethod]
		public void GetPointerNum_Test_002()
		{
			string dataType = "data*";

			int pointerNum = Util.GetPointerNum(dataType);

			Assert.AreEqual(1, pointerNum);
		}

		[TestMethod]
		public void GetPointerNum_Test_003()
		{
			string dataType = "data**";

			int pointerNum = Util.GetPointerNum(dataType);

			Assert.AreEqual(2, pointerNum);
		}

		[TestMethod]
		public void GetPointerNum_Test_004()
		{
			string dataType = "*data";

			int pointerNum = Util.GetPointerNum(dataType);

			Assert.AreEqual(0, pointerNum);
		}
	}
}
