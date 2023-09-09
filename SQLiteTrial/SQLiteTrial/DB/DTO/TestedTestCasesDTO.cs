using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.DTO
{
	public class TestedTestCasesDTO : TestCasesDTO
	{
		public string TestedVersion { get; set; } = string.Empty;
		public string TestResultCode { get; set; } = string.Empty;
		public TestersDTO Tester { get; set; } = null;

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public TestedTestCasesDTO() : base() { }
	}
}
