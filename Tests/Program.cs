using OrkEngine;
using OrkEngine.Native;
using System;
namespace Tests
{
    public class Program : IOrkEngine
    {
        public Program()// => OnLoad();
        {
            Console.WriteLine(NativeUnsafe.InvertSqrt((float)78.67));

            Console.ReadLine();
        }

        public static void Main(string[] args) => new Program();

    }
}
