SELECT 
	tested_test_cases.id
	, tested_test_cases.test_cases_id
	, test_cases.test_code AS TEST_CODE
	, tested_versions.version_code AS VERSION
	, test_result_codes.result_text AS RESULT
	, testers.company AS COMPANY
	, testers.section AS SECTION
	, testers.name AS NAME
FROM 
	tested_test_cases
LEFT JOIN test_cases
ON tested_test_cases.test_cases_id = test_cases.id
LEFT JOIN tested_versions
ON tested_test_cases.tested_version_id = tested_versions.id
LEFT JOIN test_result_codes
ON tested_test_cases.test_result_codes_id = test_result_codes.id
LEFT JOIN testers
ON tested_test_cases.testers_id = testers.id
