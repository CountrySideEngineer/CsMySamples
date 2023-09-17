using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.DTO
{
	public class TestCasesDTO
	{
		public int ID { get; set; } = -1;
		public string TestCode { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public string Detail { get; set; } = string.Empty;
		public int BaseTestId { get; set; } = -1;
		public DateTime CreatedAt { get; set; } = DateTime.MinValue;
		public DateTime UpdateAt { get; set; } = DateTime.MinValue;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestCasesDTO() { }
	}
}
