#include "pch.h"
#include <Windows.h>
#include <iostream>
#include <stdio.h>
#include <tchar.h>

VOID WINAPI GetName(long parameter, BYTE* buffer, SHORT bufferSize)
{
	_stprintf_s((TCHAR*)buffer, bufferSize, _T("SAMPLE_DATA_0x%08X"), parameter);
}

VOID WINAPI GetParameter(long parameter, long* param)
{
	*param = parameter + 10;
}
