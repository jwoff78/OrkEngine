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
    public class Program : OrkGame
    {
        private Window window;
        GameObject vobj;
        GameObject o1;
        GameObject o2;
        Texture[] textures;
        Vector3 rot;
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
            vobj = new GameObject("Island", Model.LoadModelFromFile("Small Tropical Island.obj"));

            vobj.Models[0].meshes[0].Material.Shininess = 1000;
            vobj.Scale = new Vector3(0.1f,0.1f,0.1f);

            GameObject ground = new GameObject("ground", Model.Plane);

            ground.Models[0].meshes[0].Material.DiffuseMap = new Texture("Maps/snd1.jpg");
            ground.Models[0].meshes[0].Material.SpecularMap = new Texture("Maps/terrain_mtl1_bumpamt.jpg");
            //ground.models[0].meshes[0].material.shininess = 1000f;
            ground.Scale = new Vector3(50, 50, 50);
            ground.Rotation = new Vector3(180, 0, 0);

            GameObject water = new GameObject("water", Model.Plane);
            water.Models[0].meshes[0].Material.DiffuseMap = new Texture("water.png");
            water.Scale = new Vector3(50, 50, 50);
            water.Rotation = new Vector3(180,0,0);
            water.Position = new Vector3(0,0.08f,0);

            window.AddToRenderQueue(vobj);
            window.AddToRenderQueue(water);
            window.AddToRenderQueue(ground);

            o1 = new GameObject("cube1", Model.Cube);
            o2 = new GameObject("cube2", Model.Cube);
            o2.Position = new Vector3(3,0,0);
            o1.Children.Add(window.Camera);

            window.AddToRenderQueue(o1);
            window.AddToRenderQueue(o2);

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
            float dt = (float)window.DeltaTime * 2;

            framecount++;

            if (framecount > 2)
            {
                framecount = 0;

                //vobj.models[0].texture = textures[texcount];

                texcount++;
                if (texcount >= textures.Length)
                    texcount = 0;
            }

            //vobj.rotateY(0.5f);

            if (window.KeyDown(Key.ControlLeft))
                dt *= 3;
            if (window.KeyDown(Key.Escape))
                window.Exit();
            if (window.KeyDown(Key.W))
                window.Camera.Position += window.Camera.Forward * dt;
            if (window.KeyDown(Key.A))
                window.Camera.Position -= window.Camera.Right * dt;
            if (window.KeyDown(Key.S))
                window.Camera.Position -= window.Camera.Forward * dt;
            if (window.KeyDown(Key.D))
                window.Camera.Position += window.Camera.Right * dt;
            if (window.KeyDown(Key.Left))
                window.Camera.Rotation += new Vector3(0, 0.1f, 0);
            if (window.KeyDown(Key.Right))
                window.Camera.Rotation += new Vector3(0,-0.1f, 0);
            if (window.KeyDown(Key.Space))
                window.Camera.Position += window.Camera.Up * dt;
            if (window.KeyDown(Key.LShift))
                window.Camera.Position -= window.Camera.Up * dt;

            o1.Rotation += new Vector3(0,0.1f,0);

            return null;
        }
    }
}
