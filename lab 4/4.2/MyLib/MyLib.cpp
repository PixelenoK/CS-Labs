#include "pch.h"
#include <utility>
#include <limits.h>
#include "MyLib.h"
#include <iostream>

int Get_PositiveNeg(int number)
{
	if (number >= 0)
		return 1;
	else
		return -1;
}

int Get_length(int number)
{
	int number_copy = number;
	int length = 0;

	while(number_copy != 0)
	{
		number_copy /= 10;

		++length;
	}

	return length;
}

int Odd_or_even(int number)
{
	if (number % 2 == 0)
		return 1;
	else
		return -1;
}