using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.DTO
{
	public class TestersDTO
	{
		public int ID { get; set; } = -1;
		public string TesterCode { get; set; } = string.Empty;
		public string Company { get; set; } = string.Empty;
		public string Section { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; } = DateTime.MinValue;
		public DateTime UpdateAt { get; set; } = DateTime.MinValue;

		/// <summary>
		/// Default cosntructor.
		/// </summary>
		public TestersDTO() { }
	}
}
