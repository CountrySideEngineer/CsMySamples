#include "pch.h"
#include <Windows.h>
#include <tchar.h>

#ifdef __cplusplus
extern "C" {
#endif
	/**
	 * @brief	Sample method to export.
	 *			This method returns sum of 2 values.
	 *  
	 * @param	value1	A value to add.
	 * @param	value2	A value to add.
	 * @return	Result of the calculation.
	 */
	__declspec(dllexport) int Add(int value1, int value2)
	{
		_tprintf(_T("LoadNativeDynamicLinkLibrary\n"));
		_tprintf(_T("%s\n"), __FUNCTIONW__);
		_tprintf(_T("value1 = %d\n"), value1);
		_tprintf(_T("value2 = %d\n"), value2);

		return (value1 + value2);
	}

	/**
	 * @brief	Sample method to export.
	 *			This method returns sum of values.
	 * 
	 * @param	Pointer to the collection to add.
	 * @param	The number of value to add.
	 * @return	The sum of values.
	 */
	__declspec(dllexport) int Sum(int* values, int valueCount)
	{
		_tprintf(_T("LoadNativeDynamicLinkLibrary\n"));
		_tprintf(_T("%s\n"), __FUNCTIONW__);

		LONG	sum = 0;
		for (int index = 0; index < valueCount; index++)
		{
			_tprintf(_T("value%d = %d\n"), (index + 1), *values);
			sum += *values;
			values++;
		}
		return sum;
	}
#ifdef __cplusplus
}
#endif