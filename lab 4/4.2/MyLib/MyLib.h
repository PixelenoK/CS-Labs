#pragma once

#ifdef MYLIB_EXPORTS
#define MYLIB_API __declspec(dllexport)

#else
#define MYLIB_API __declspec(dllimport)
#endif


extern "C" MYLIB_API int Get_PositiveNeg(int number);

extern "C" MYLIB_API int Get_length(int number);

extern "C" MYLIB_API int Odd_or_even(int number);