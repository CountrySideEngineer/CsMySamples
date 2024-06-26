﻿using SQLiteTrial.DB.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTrial.DB.Connection.SQLite
{
	public class TestedTestCaseDAO : IDbAccess
	{
		public object SelectAll()
		{
			List<TestedTestCasesDTO> testedtestCases = null;
			string query =
				"SELECT " +
				"tested_test_cases.id " +
					", tested_test_cases.test_cases_id " +
					", test_cases.test_code AS TEST_CODE " +
					", tested_versions.version_code AS VERSION " +
					", test_result_codes.result_text AS RESULT " +
					", testers.company AS COMPANY " +
					", testers.section AS SECTION " +
					", testers.name AS NAME " +
				"FROM " +
					"tested_test_cases " +
				"LEFT JOIN test_cases " +
					"ON tested_test_cases.test_cases_id = test_cases.id " +
				"LEFT JOIN tested_versions " +
					"ON tested_test_cases.tested_version_id = tested_versions.id " +
				"LEFT JOIN test_result_codes " +
					"ON tested_test_cases.test_result_codes_id = test_result_codes.id " +
				"LEFT JOIN testers " +
				"ON tested_test_cases.testers_id = testers.id ";
			using (var connection = new Connector())
			using (SQLiteDataReader reader = connection.ExecuteQuery(query))
			{
				testedtestCases = new List<TestedTestCasesDTO>();
				while (reader.Read())
				{
					int id = Convert.ToInt32(reader["ID"]);
					string testCode = reader["TEST_CODE"].ToString();
					string version = string.Empty;
					if (DBNull.Value != reader["VERSION"])
					{
						version = reader["VERSION"].ToString();
					}
					string result = string.Empty;
					if (DBNull.Value != reader["RESULT"])
					{
						result = reader["RESULT"].ToString();
					}
					string company = string.Empty;
					if (DBNull.Value != reader["COMPANY"])
					{
						company = reader["COMPANY"].ToString();
					}
					string section = string.Empty;
					if (DBNull.Value != reader["SECTION"])
					{
						section = reader["SECTION"].ToString();
					}
					string name = string.Empty;
					if (DBNull.Value != reader["NAME"])
					{
						name = reader["NAME"].ToString();
					}
					var testedTestCase = new TestedTestCasesDTO()
					{
						ID = id,
						TestCode = testCode,
						TestedVersion = version,
						TestResultCode = result,
						Tester = new TestersDTO()
						{
							Company = company,
							Section = section,
							Name = name
						}
					};
					testedtestCases.Add(testedTestCase);
				}
				reader.Close();
			}
			return testedtestCases;
		}

		public object Delete(object dto)
		{
			throw new NotImplementedException();
		}

		public object Insert(object dto)
		{
			throw new NotImplementedException();
		}

		public object Select(object dto)
		{
			throw new NotImplementedException();
		}

		public object Update(object dto)
		{
			var testedTestCaseDto = (TestedTestCasesDTO)dto;
			string query =
				$"UPDATE tested_test_cases " +
				$"SET " +
					$"test_result_codes_id = " +
					$"(" +
						$"SELECT id FROM test_result_codes WHERE test_result_codes.result_text = @code" +
					$")," +
					$"testers_id = " +
					$"(" +
						$"SELECT id FROM testers " +
						$"WHERE " +
							$"testers.company = @company AND " +
							$"testers.section = @section AND " +
							$"testers.name = @name" +
					$")," +
					$"updated_at = CURRENT_TIMESTAMP " +
				$"WHERE " +
					$"test_cases_id = " +
					$"(" +
						$"SELECT id FROM test_cases WHERE test_cases.test_code = @test_code" +
					$");";
			var parameters = new Dictionary<string, object>();
			parameters.Add("@version", testedTestCaseDto.TestedVersion);
			parameters.Add("@code", testedTestCaseDto.TestResultCode);
			parameters.Add("@company", testedTestCaseDto.Tester.Company);
			parameters.Add("@section", testedTestCaseDto.Tester.Section);
			parameters.Add("@name", testedTestCaseDto.Tester.Name);
			parameters.Add("@test_code", testedTestCaseDto.TestCode);
			using (var connection = new Connector())
			{
				connection.BeginTransaction();

				int count = connection.ExecuteNonQuery(query, parameters);

				connection.Commit();

				return count;
			}
		}
	}
}
