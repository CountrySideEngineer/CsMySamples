using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.Connection
{
	public interface IDbAccess
	{
		object SelectAll();
		object Select(object dto);
		object Insert(object dto);
		object Update(object dto);
		object Delete(object dto);
	}
}
