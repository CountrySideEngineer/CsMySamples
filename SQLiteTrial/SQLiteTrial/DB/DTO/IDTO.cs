using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.DTO
{
	public interface IDTO
	{
		Dictionary<string, object> GetParameters(string prefix = "@");
	}
}
