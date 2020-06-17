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
using System.Runtime.ConstrainedExecution;
using OrkEngine;
using System.Security.Cryptography;
using OpenTK.Graphics.ES20;

namespace Tests
{
    public class Program : IOrkEngine
    {
        private Window window;
        GameObject vobj;
        Texture[] textures;
        int texcount = 0;
        int framecount = 0;

        public static void Main(string[] args)
        {
            new Program();
        }

        public Program() {
            window = new Window(1600, 900, "OrkEngine", Start, Update);
            window.Run(60.0);
            window.Dispose();
        }

        public object Start()
        {
            vobj = new GameObject("earth", Model.LoadModelFromFile("Earth 2K.obj"));
            vobj.ActiveModel.texture = new Texture("Textures/Diffuse_2K.png");
            vobj.ActiveModel.renderMode = Model.RenderMode.Quads;

            window.AddToRenderQueue(vobj);

            string[] tex = Directory.GetFiles(@"Textures\VeryMuchVroooom");
            textures = new Texture[tex.Length];

            for (int i = 0; i < tex.Length; i++)
            {
                //textures[i] = new Texture(tex[i]);
            }

            return null;
        }

        public object Update()
        {
            framecount++;

            if (framecount > 2)
            {
                framecount = 0;

                //vobj.models[0].texture = textures[texcount];

                texcount++;
                if (texcount >= textures.Length)
                    texcount = 0;
            }

            vobj.rotation += new Vector3(0.005f, 0.01f, 0);

            if (window.KeyDown(Key.Escape))
                window.Exit();
            if (window.KeyDown(Key.W))
                window.camera.Position += window.camera.Front * (float)window.deltaTime * 2;
            if (window.KeyDown(Key.A))
                window.camera.Position -= window.camera.Right * (float)window.deltaTime * 2;
            if (window.KeyDown(Key.S))
                window.camera.Position -= window.camera.Front * (float)window.deltaTime * 2;
            if (window.KeyDown(Key.D))
                window.camera.Position += window.camera.Right * (float)window.deltaTime * 2;
            if (window.KeyDown(Key.Left))
                window.camera.Yaw -= 1;
            if (window.KeyDown(Key.Right))
                window.camera.Yaw += 1;

            return null;
        }
    }
}
