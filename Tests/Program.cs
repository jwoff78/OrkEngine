using System;
using System.Collections.Generic;
using System.IO;
using OpenTK;
using OrkEngine.Graphics;
using OrkEngine.Graphics.Common;
using OpenTK.Input;
using OrkEngine;
using BEPUphysics.Entities.Prefabs;
using numVec3 = System.Numerics.Vector3;
using BEPUphysics.BroadPhaseEntries;

namespace Tests
{
    public class Program : IOrkEngine
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

            vobj.models[0].meshes[0].material.shininess = 1000;
            vobj.scale = new Vector3(0.05f,0.05f,0.05f);
            vobj.EntityOrStatic = true;

            GameObject ground = new GameObject("ground", Model.Plane);
            ground.models[0].meshes[0].material.diffuseMap = new Texture("Maps/snd1.jpg");
            ground.models[0].meshes[0].material.specularMap = new Texture("Maps/terrain_mtl1_bumpamt.jpg");
            ground.scale = new Vector3(50, 50, 50);

            GameObject water = new GameObject("water", Model.Plane);
            water.models[0].meshes[0].material.diffuseMap = new Texture("water.png");
            water.scale = new Vector3(50, 50, 50);
            water.position = new Vector3(0,0.025f,0);

            window.AddToRenderQueue(vobj);
            window.AddToRenderQueue(ground);
            window.AddToRenderQueue(water, false);

            string[] tex = Directory.GetFiles(@"Textures\VeryMuchVroooom");
            textures = new Texture[tex.Length];

            for (int i = 0; i < tex.Length; i++)
            {
                //textures[i] = new Texture(tex[i]);
            }

            /*GameObject g = new GameObject("ground", Model.Cube);
            g.scale = new Vector3(10,0.5f,10);
            g.models[0].meshes[0].material.diffuseMap = new Texture("Maps/snd1.jpg");
            g.models[0].meshes[0].material.specularMap = new Texture("Maps/terrain_mtl1_bumpamt.jpg");
            g.entity = new Box(numVec3.Zero, g.scale.X, g.scale.Y, g.scale.Z);
            g.entity.Position = new numVec3(0,-1,0);*/

            GameObject cube = new GameObject("cube", Model.Cube);
            //.scale = new Vector3(01f, 0.1f, 0.1f);
            cube.entity = new Box(numVec3.Zero, cube.scale.X, cube.scale.Y * 2, cube.scale.Z, 1);
            cube.entity.Position = new numVec3(0, 20, 0);

            //window.AddToRenderQueue(g);
            window.AddToRenderQueue(cube);

            //window.space.Add(window.camera.entity);

            return null;
        }

        public object Update()
        {
            float dt = (float)window.deltaTime * 2;

            /*framecount++;

            if (framecount > 2)
            {
                framecount = 0;

                //vobj.models[0].texture = textures[texcount];

                texcount++;
                if (texcount >= textures.Length)
                    texcount = 0;
            }

            //vobj.rotateY(0.5f);*/

            Vector3 cf = window.camera.forward;
            numVec3 camForward = new numVec3(cf.X, cf.Y, cf.Z);

            Vector3 cr = window.camera.right;
            numVec3 camRight = new numVec3(cr.X, cr.Y, cr.Z);

            Vector3 cu = window.camera.up;
            numVec3 camUp = new numVec3(cu.X, cu.Y, cu.Z);

            if (window.KeyDown(Key.ControlLeft))
                dt *= 3;
            if (window.KeyDown(Key.Escape))
                window.Exit();
            if (window.KeyDown(Key.W))
                window.camera.entity.Position += camForward * dt;
            if (window.KeyDown(Key.A))
                window.camera.entity.Position -= camRight * dt;
            if (window.KeyDown(Key.S))
                window.camera.entity.Position -= camForward * dt;
            if (window.KeyDown(Key.D))
                window.camera.entity.Position += camRight * dt;
            if (window.KeyDown(Key.Left))
                window.camera.rotation += new Vector3(0, 0.1f, 0);
            if (window.KeyDown(Key.Right))
                window.camera.rotation += new Vector3(0,-0.1f, 0);
            if (window.KeyDown(Key.Space))
                window.camera.entity.Position += camUp * dt;
            if (window.KeyDown(Key.LShift))
                window.camera.entity.Position -= camUp * dt;

            //o1.rotation += new Vector3(0,0.1f,0);

            return null;
        }
    }
}
