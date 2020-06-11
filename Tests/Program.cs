using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OrkEngine.Graphics;

namespace Tests
{
    class Program
    {
        Window render;

        public static void Main(string[] args)
        {
            new Program();
        }

        public Program() {
            render = new Window(1600, 900, "OrkEngine", Start, Update);
            render.Run(60.0);
            render.Dispose();
        }

        public object Start()
        {

            return null;
        }
        public object Update()
        {
            return null;
        }
    }
}
