using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrkEngine.Interface;
using System.IO;
using OpenGL;

namespace Tests
{
    class Program
    {
        Renderable vcube;
        Renderable r;

        bool mode = true;
        float[] limits = {-1.5f, 1.5f};
        int[] counter = {0, 10};
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello, world");
            new Program();
        }
        public Program()
        {
            GameWindow g = new GameWindow(Start, Update);
        }
        public object Start()
        {
            Console.WriteLine("Start");

            return null;
        }
        public object Update()
        {
            return null;
        }
    }
}
