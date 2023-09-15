using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.DTO
{
	public class TestedVersionDTO
	{
		public int ID { get; set; } = -1;
		public string VersionCode { get; set; } = string.Empty;
		public int PreVersionID { get; set; } = -1;
		public DateTime CreatedAt { get; set; } = DateTime.MinValue;
		public DateTime UpdateAt { get; set; } = DateTime.MinValue;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestedVersionDTO() { }
	}
}
