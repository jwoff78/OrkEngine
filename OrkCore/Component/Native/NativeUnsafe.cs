using System;
using System.Runtime.InteropServices;

namespace OrkEngine.Native
{
    public class NativeUnsafe
    {
        #region InvertSqrt
        [DllImport("OrkEngineUnsafe.dll", EntryPoint = "InvertSqrt")]
        public static extern float InvertSqrt(float x);
        #endregion
    }
}
