#include "pch.h"
#include <iostream>
#include <Windows.h>

#define	PROGRESS_SIZE		(10)

SHORT	progress[PROGRESS_SIZE];

VOID
WINAPI
InitProgress()
{
	for (int index = 0; index < PROGRESS_SIZE; index++) {
		progress[index] = 0;
	}
}

VOID
WINAPI
GetProgresses(
	SHORT*	progresses,
	LONG	progressNum,
	LONG*	actProgressNum
)
{
	LONG	numToSet = progressNum;
	if (PROGRESS_SIZE < numToSet) {
		numToSet = PROGRESS_SIZE;
	}

	for (LONG index = 0; index < numToSet; index++) {
		progresses[index] = progress[index];
	}

	*actProgressNum = numToSet;
}

VOID
WINAPI
RunProgress(SHORT interval)
{
	for (int index1 = 0; index1 < PROGRESS_SIZE; index1++) {
		for (int index2 = 0; index2 < 100; index2++) {
			progress[index1] = index2;
			Sleep(interval);
		}
	}
}
