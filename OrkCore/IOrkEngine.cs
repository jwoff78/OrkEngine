using OpenTK;
using OpenTK.Input;
using OrkEngine.Graphics;
using OrkEngine.Graphics.Common;
using System;

namespace OrkEngine
{
    public class IOrkEngine : IDisposable
    {
        private EngineCore engine = new EngineCore();

        /// <summary>
        /// Calls all of the private methods for an initilization.
        /// </summary>
        public IOrkEngine()
        {
            SignatureCheck();
        }

        /// <summary>
        /// Does a bunch of checks to make sure the whole engine is here, and also checks file health.
        /// </summary>
        private void SignatureCheck()
        {
            //bool isTrue = 10 > 5;
        }

        /// <summary>
        /// Run's first thing before anything else is called, OnStart, OnUpdate, Etc...
        /// </summary>
        public void OnLoad()
        {
            engine.Load();
        }

        /// <summary>
        /// The start up function for JarCore
        /// </summary>
        public void OnStart()
        {
            engine.Start();
        }

        public void OnUpdate()
        {
            engine.Update();
        }

        public void OnFixedUpdate()
        {
        }

        public void OnLateUpdate()
        {
        }

        public void OnDisable()
        {
        }

        public void OnRender()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool dumping)
        {
            if (dumping) Dump();
        }

        /// <summary>
        /// Deletes all of the object holders.
        /// </summary>
        private void Dump()
        {

        }
    }

    internal sealed class EngineCore
    {
        public EngineCore() { /* don't call init */ }

        private Window render;
        private Renderable car;
        private Vector3 carpos = new Vector3(0, 0, 0);

        public void Load()
        {
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

            car.position = new Vector3(0, 0, 5);

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