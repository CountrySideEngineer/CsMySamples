#include "pch.h"
#include <Windows.h>
#include <tchar.h>
#include <thread>

typedef void(__stdcall* ProgressNotification)(long data);

void WINAPI BackgroundWork(ProgressNotification callback)
{
	for (long index = 0; index <= 100; index++) {
		if (NULL != callback) {
			callback(index);

			Sleep(20);
		}
	}
}

DWORD WINAPI BackgroundWorkThread(LPVOID parameter)
{
	ProgressNotification callback = (ProgressNotification)parameter;

	BackgroundWork(callback);

	return 0;
}

void WINAPI BackgroundWorkAsync(ProgressNotification callback)
{
	DWORD threadID = 0;


	CreateThread(NULL,
		0,
		BackgroundWorkThread,
		(LPVOID)callback,
		0,
		&threadID);

	_tprintf(_T("threadId = %d\n"), threadID);
}
