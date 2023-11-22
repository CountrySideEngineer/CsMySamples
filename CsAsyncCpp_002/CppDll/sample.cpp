#include "pch.h"
#include <iostream>
#include <Windows.h>

SHORT	enumrator = 0;
SHORT	denominator = 0;

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

VOID
WINAPI
Process(BYTE span)
{
	denominator = 100;
	for (int index = 0; index < 100; index++) {
		enumrator = (index + 1);

		Sleep(span * 10);
	}
}
