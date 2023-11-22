#include "pch.h"
#include <iostream>
#include <Windows.h>

SHORT	enumrator;
SHORT	denominator;

VOID
WINAPI
GetProgressByPointer(
	BYTE* progress
)
{
	if (0 == denominator) {
		*progress = 0;
	}
	else {
		USHORT progTemp = (100 * enumrator) / denominator;

		*progress = (BYTE)progTemp;
	}
}

BYTE
WINAPI
GetProgressByReturn()
{
	BYTE progress = 0;

	GetProgressByPointer(&progress);

	return progress;
}
