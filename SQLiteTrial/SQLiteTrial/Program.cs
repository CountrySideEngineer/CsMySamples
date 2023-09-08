using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteTrial.DB.Connection.SQLite;

namespace SQLiteTrial
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (var dbConnector = new Connector())
			{
				Console.WriteLine("Sample output.");
			}

			return;
		}
	}
}
