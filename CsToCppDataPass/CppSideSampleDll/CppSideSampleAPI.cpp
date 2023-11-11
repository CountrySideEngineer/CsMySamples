#include "pch.h"
#include <iostream>
#include <Windows.h>

typedef struct _SAMPLE_STRUCT_DATA
{
	SHORT	paramA;
	SHORT	paramB;
	LONG	result;
} SAMPLE_STRUCT;

SHORT
WINAPI
CppSideSampleIF(SAMPLE_STRUCT* input)
{
	LONG result = input->paramA + input->paramB;

	input->result = result;

	return result;
}

SHORT
WINAPI
CppSideSampleIF2(short inputA, short inputB)
{
	SHORT result = inputA + inputB;

	return result;
}
