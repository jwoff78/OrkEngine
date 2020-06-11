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
        Renderable obj;

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
            rend.texture = new Texture("gentleman.png");

            rend.rotation = new Vector3(1,2,3);
            rend.position = new Vector3(0, 2, 0);

            obj = Renderable.LoadFromFile("vroooomcube2.obj", "objcube");

            obj.texture = new Texture("Cube9_auv.png");

            obj.position = new Vector3(0,0,5);

            Console.WriteLine("VertVals: " + obj.vertices.Length);
            Console.WriteLine("Elements: " + obj.indices.Length);

            render.AddToRenderQueue(rend);
            render.AddToRenderQueue(obj);

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

            obj.rotation += new Vector3(0.01f, 0.015f, 0);

            return null;
        }
    }
}
