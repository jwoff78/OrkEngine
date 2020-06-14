using System;
using System.Runtime.InteropServices;

namespace OrkEngine.Native
{
    public class NativeUnsafe
    {
        [DllImport("OrkEngineUnsafe.dll", EntryPoint = "InvertSqrt")]
        public static extern float InvertSqrt(float x);
    }
}
