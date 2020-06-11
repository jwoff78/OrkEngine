using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OrkEngine.Graphics;
using OrkEngine.Graphics.Common;
using OpenTK.Input;

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
            Console.WriteLine("Start");

            Renderable rend = Renderable.Cube;
            rend.texture = new Texture("vroooom.png");

            render.AddToRenderQueue(rend);

            Console.WriteLine("Start");
            return null;
        }
        public object Update()
        {
            if (render.KeyDown(Key.Escape))
                render.Exit();
            if (render.KeyDown(Key.W))
                render.camera.Position += render.camera.Front * (float)render.deltaTime * 2;
            if (render.KeyDown(Key.A))
                render.camera.Position -= render.camera.Right * (float)render.deltaTime * 2;
            if (render.KeyDown(Key.S))
                render.camera.Position -= render.camera.Front * (float)render.deltaTime * 2;
            if (render.KeyDown(Key.D))
                render.camera.Position += render.camera.Right * (float)render.deltaTime * 2;
            if (render.KeyDown(Key.Left))
                render.camera.Yaw -= 1;
            if (render.KeyDown(Key.Right))
                render.camera.Yaw += 1;

            return null;
        }
    }
}
