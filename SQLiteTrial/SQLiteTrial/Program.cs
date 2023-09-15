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
			var dao = new TestedTestCaseDAO();
			var testedTestCaseDto = new TestedTestCasesDTO()
			{
				TestCode = "sample_test_code_001_002",
				TestedVersion = "1.0.0",
				TestResultCode = "NG",
				Tester = new TestersDTO()
				{
					Company = "COMPANY_001",
					Section = "SECTION_001",
					Name = "TESTER_NAME_001"
				}
			};
			dao.Update(testedTestCaseDto);





			IEnumerable<TestedTestCasesDTO> dtos = (IEnumerable<TestedTestCasesDTO>)dao.SelectAll();
			foreach (var dto in dtos)
			{
				Console.WriteLine($"ID = {dto.ID.ToString().PadLeft(6)}, " +
					$"code = {dto.TestCode.PadLeft(18)}, " +
					$"reuslt = {dto.TestResultCode.PadLeft(8)}");
			}

			var testCaseDto = new TestCasesDTO()
			{
				TestCode = "sample_test_code_002_006",
				Summary = "Sample test code, code 003-001",
				Detail = "Sample test code, code 003-001",
			};
			var testCaseDao = new TestCaseDAO();
			testCaseDao.Insert(testCaseDto);

			

			return;
		}
	}
}
