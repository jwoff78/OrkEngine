extern "C"
{
	__declspec(dllexport) float __stdcall InvertSqrt(float x) {
		float xhalf = 0.5f * x;
		int i = *(int*)&x;
		i = 0x5f3759df - (i >> 1);
		x = *(float*)&i;
		x = x * (1.5f - xhalf * x * x);
		return x;
	}
}


extern "C"
{
	__declspec(dllexport) int __stdcall power2(int num, int power)
	{
		__asm
		{
			mov eax, num    ; Get first argument
			mov ecx, power  ; Get second argument
			shl eax, cl     ; EAX = EAX * (2 to the power of CL)
		}
		//return with result in EAX;
	}
}