using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.DTO
{
	public class DTOCommon : IDTO
	{
		public DateTime CreatedAt { get; set; } = DateTime.MinValue;
		public DateTime UpdateAt { get; set; } = DateTime.MinValue;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DTOCommon() { }

		public virtual Dictionary<string, object> GetParameters(string prefix = "@")
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add($"{prefix}cretaed_at", CreatedAt);
			parameters.Add($"{prefix}update_at", UpdateAt);

			return parameters;
		}
	}
}
