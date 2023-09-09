using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteTrial.DB.Connection.SQLite;
using SQLiteTrial.DB.DTO;

namespace SQLiteTrial
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var dao = new TestersDAO();
			IEnumerable<TestersDTO> testers = (IEnumerable<TestersDTO>)dao.SelectAll();
			foreach (var item in testers)
			{
				Console.WriteLine($"ID = {item.ID.ToString().PadLeft(6)}, Tester code = {item.TesterCode}, Name = {item.Name}");

				item.TesterCode = $"{item.TesterCode}_SUB_{DateTime.Now.ToString()}";
			}




			foreach (var item in testers)
			{
				dao.Insert(item);
			}

			return;
		}
	}
}
