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
using OrkEngine.Interface.UI.Core;
using System.Runtime.ConstrainedExecution;

namespace Tests
{
    class Program
    {
        Window render;
        Renderable car;
        Vector3 carpos = new Vector3(0,0,0);

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

            rend.position = new Vector3(0, 2, 0);

            car = Renderable.LoadFromFile("Chevrolet_Camaro_SS_Low.obj", "car");

            car.texture = new Texture("vroooom.png");

            car.renderMode = Renderable.RenderMode.Lines;

            car.position = new Vector3(0,0,5);

            Renderable ground = Renderable.LoadFromFile("plane.obj", "ground");
            ground.texture = new Texture("Cube1_auv.png");
            ground.position = new Vector3(0, -2, 0);

            render.AddToRenderQueue(ground);
            render.AddToRenderQueue(rend);
            render.AddToRenderQueue(car);

            render.camera.LookAtMode = true;

            Console.WriteLine("Start");
            return null;
        }
        public object Update()
        {
            if (render.KeyDown(Key.Escape))
                render.Exit();
            if (render.KeyDown(Key.W))
                carpos -= car.forward * (float)render.deltaTime * 4;
            if (render.KeyDown(Key.A))
            {
                car.rot.Y += 0.01f;
            }
            if (render.KeyDown(Key.S))
                carpos += car.forward * (float)render.deltaTime * 4;
            if (render.KeyDown(Key.D))
            {
                car.rot.Y -= 0.01f;
            }

            car.position = carpos;
            //render.camera.Position = carpos + new Vector3(0,1,0);
            //render.camera.LookTarget = carpos;
            //obj.rotation += new Vector3(0.00f, 0.015f, 0);

            return null;
        }
    }
}
