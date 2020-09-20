using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System.Runtime.ConstrainedExecution;
using OrkEngine;
using System.Security.Cryptography;
using OpenTK.Graphics.ES20;

namespace Tests
{
    public class Program : OrkGame
    {
        /*
        GameObject vobj, o1, o2;
        Texture[] textures;
        int texcount = 0, framecount = 0;

        public static void Main()
        {
            using (var game = new Program())
                game.Start();
        }

        public Program() : base("OrkEngine", 1600, 900) { }

        protected override void OnStart()
        {
            vobj = new GameObject("Island", Model.LoadModelFromFile("Small Tropical Island.obj"));

            vobj.models[0].meshes[0].material.shininess = 1000;
            vobj.scale = new Vector3(0.1f, 0.1f, 0.1f);

            GameObject ground = new GameObject("ground", Model.Plane);

            ground.models[0].meshes[0].material.diffuseMap = new Texture("Maps/snd1.jpg");
            ground.models[0].meshes[0].material.specularMap = new Texture("Maps/terrain_mtl1_bumpamt.jpg");
            //ground.models[0].meshes[0].material.shininess = 1000f;
            ground.scale = new Vector3(50, 50, 50);
            ground.rotation = new Vector3(180, 0, 0);

            GameObject water = new GameObject("water", Model.Plane);
            water.models[0].meshes[0].material.diffuseMap = new Texture("water.png");
            water.scale = new Vector3(50, 50, 50);
            water.rotation = new Vector3(180, 0, 0);
            water.position = new Vector3(0, 0.08f, 0);

            AddObject(vobj);
            AddObject(water);
            AddObject(ground);

            o1 = new GameObject("cube1", Model.Cube);
            o2 = new GameObject("cube2", Model.Cube);
            o2.position = new Vector3(3, 0, 0);
            o1.Children.Add(Camera);

            AddObject(o1);
            AddObject(o2);

            string[] tex = Directory.GetFiles(@"Textures\VeryMuchVroooom");
            textures = new Texture[tex.Length];

            //for (int i = 0; i < tex.Length; i++)
            //{
                //textures[i] = new Texture(tex[i]);
            //}
        }

        protected override void OnUpdate(double deltaTime)
        {
            float dt = (float)deltaTime * 2;

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

            if (KeyDown(Key.ControlLeft))
                dt *= 3;
            if (KeyDown(Key.Escape))
                Stop();
            if (KeyDown(Key.W))
                Camera.position += Camera.forward * dt;
            if (KeyDown(Key.A))
                Camera.position -= Camera.right * dt;
            if (KeyDown(Key.S))
                Camera.position -= Camera.forward * dt;
            if (KeyDown(Key.D))
                Camera.position += Camera.right * dt;
            if (KeyDown(Key.Left))
                Camera.rotation += new Vector3(0, 0.1f, 0);
            if (KeyDown(Key.Right))
                Camera.rotation += new Vector3(0, -0.1f, 0);
            if (KeyDown(Key.Space))
                Camera.position += Camera.up * dt;
            if (KeyDown(Key.LShift))
                Camera.position -= Camera.up * dt;

            o1.rotation += new Vector3(0, 0.1f, 0);
        }
        */
    }
}
