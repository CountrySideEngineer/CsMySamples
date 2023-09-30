using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.DTO
{
	public class TestResultCodesDTO
	{
		public int ID { get; set; } = -1;
		public string ResultText { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; } = DateTime.MinValue;
		public DateTime UpdateAt { get; set; } = DateTime.MinValue;


		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestResultCodesDTO() : base() { }
	}
}
