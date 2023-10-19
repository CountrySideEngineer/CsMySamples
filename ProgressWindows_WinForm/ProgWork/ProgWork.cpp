#include "pch.h"
#include <Windows.h>
#include <tchar.h>
#include <thread>

static bool isContinueWork = false;
static bool isRunning = false;

typedef void(__stdcall* ProgressNotification)(long data);

void WINAPI BackgroundWork(ProgressNotification callback)
{
	for (long index = 0; index <= 100; index++) {
		if (!isContinueWork) {
			break;
		}
		if (NULL != callback) {
			callback(index);

			Sleep(100);
		}
	}
	isRunning = false;
}

DWORD WINAPI BackgroundWorkThread(LPVOID parameter)
{
	isRunning = true;

	ProgressNotification callback = (ProgressNotification)parameter;

	BackgroundWork(callback);

	return 0;
}

void WINAPI BackgroundWorkAsync(ProgressNotification callback)
{
	DWORD threadID = 0;

	isContinueWork = true;

	CreateThread(NULL,
		0,
		BackgroundWorkThread,
		(LPVOID)callback,
		0,
		&threadID);

	_tprintf(_T("threadId = %d\n"), threadID);
}

void WINAPI BackgroundWorkCancle()
{
	isContinueWork = false;
}

bool WINAPI GetBackgroundWorkState()
{
	return isRunning;
}
