#include "pch.h"
#include <iostream>
#include <random>
#include <Windows.h>

typedef struct _DataItemTag
{
	SHORT		IsChecked;
	LONG		Progress;
	ULONGLONG	Result;
} DataItemTag;

#define	PROGRESS_SIZE		(4)

SHORT	progress[PROGRESS_SIZE];
SHORT	result[PROGRESS_SIZE];

VOID
WINAPI
InitProgress()
{
	for (int index = 0; index < PROGRESS_SIZE; index++) {
		progress[index] = 0;
		result[index] = 0;
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
GetResult(
	SHORT*	results,
	LONG	resultNum,
	LONG*	actResultNum
)
{
	LONG	numToSet = resultNum;
	if (PROGRESS_SIZE < numToSet) {
		numToSet = PROGRESS_SIZE;
	}

	for (LONG index = 0; index < numToSet; index++) {
		results[index] = result[index];
	}
	*actResultNum = numToSet;
}

VOID
WINAPI
RunProgress(SHORT interval, DataItemTag* items, LONG itemCount)
{
	srand((unsigned int)time(NULL));

	for (int index1 = 0; index1 < PROGRESS_SIZE; index1++) {
		DataItemTag itemTag = items[index1];
		if (itemTag.IsChecked) {
			for (int index2 = 0; index2 < 100; index2++) {
				progress[index1] = (index2 + 1);
				Sleep(interval);
			}
			result[index1] = ((SHORT)rand()) % 0x07FF;
		}
		else {
			progress[index1] = 0;
			result[index1] = 0;
		}
	}
	Sleep(interval * 2);
}
