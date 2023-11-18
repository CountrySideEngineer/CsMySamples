#include "pch.h"
#include <iostream>
#include <Windows.h>

typedef VOID(*PROGRESS_CALLBACK)(SHORT numerator, SHORT denominator);
typedef VOID(*RESULT_CALLBACK)(ULONG result);

PROGRESS_CALLBACK	progressCallback = NULL;
RESULT_CALLBACK		resultCallback = NULL;

VOID
InitSample()
{
	progressCallback = NULL;
	resultCallback = NULL;
}

VOID
WINAPI
SetProgressCallback(
	PROGRESS_CALLBACK callback
)
{
	progressCallback = callback;
}


VOID
WINAPI
SetResultCallback(
	RESULT_CALLBACK callback
)
{
	resultCallback = callback;
}

VOID
NotifyProgress(
	SHORT numerator,
	SHORT denominator
)
{
	if (NULL != progressCallback) {
		progressCallback(numerator, denominator);
	}
}

VOID
NotifyResult(
	ULONG result
)
{
	if (NULL != resultCallback) {
		resultCallback(result);
	}
}

#define	PROCESS_MAX			(1000)

VOID
WINAPI
Process()
{
	for (int index = 0; index < PROCESS_MAX; index++) {
		Sleep(100);

		NotifyProgress((SHORT)(index + 1), (SHORT)PROCESS_MAX);
	}

	NotifyResult(0);
}
