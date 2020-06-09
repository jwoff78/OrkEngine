﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

namespace JJGE_Core.Interface
{
    public class Renderable
    {
        public string name = "OBJECT";
        public Vector3[] vertices;
        public uint[] elements;
        public Vector2[] uvs;
        public Vector3[] normals;
        public Texture texture;
        public Vector3 position = new Vector3(0,0,0);
        public BeginMode beginmode = BeginMode.Triangles;
        public Vector3 rotation = new Vector3(0,0,0);

        VBO<Vector3> vert;
        VBO<Vector3> norm;
        VBO<Vector2> uv;
        VBO<uint> elm;

        public Renderable(string Name)
        {
            name = Name;
        }
        public Renderable(string Name, Vector3[] Verts, uint[] Elements, Vector2[] Uvs, Vector3[] Normals, Texture Tex)
        {
            name = Name;
            vertices = Verts;
            elements = Elements;
            uvs = Uvs;
            normals = Normals;
            texture = Tex;
        }

        public void PrepareVBOs()
        {
            vert = new VBO<Vector3>(vertices);
            norm = new VBO<Vector3>(normals);
            uv = new VBO<Vector2>(uvs);
            elm = new VBO<uint>(elements, BufferTarget.ElementArrayBuffer);
        }

        public object[] GetVBOs
        {
            get
            {
                object[] o = new object[4];
                o[0] = vert;
                o[1] = norm;
                o[2] = uv;
                o[3] = elm;
                return o;
            }
        }

        public void DisposeVBOs()
        {
            vert.Dispose();
            norm.Dispose();
            uv.Dispose();
            elm.Dispose();
            texture.Dispose();
        }

        public static Renderable Cube
        {
            get{
                Renderable cube = new Renderable("VroooomCube");
                cube.vertices = new Vector3[] {
                    new Vector3(1, 1, -1), new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1),
                    new Vector3(1, -1, 1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1), new Vector3(1, -1, -1),
                    new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1),
                    new Vector3(1, -1, -1), new Vector3(-1, -1, -1), new Vector3(-1, 1, -1), new Vector3(1, 1, -1),
                    new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, -1), new Vector3(-1, -1, 1),
                    new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1) };
                cube.elements = new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
                cube.uvs = new Vector2[] {
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };
                cube.normals = new Vector3[] {
                    new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0),
                    new Vector3(0, -1, 0), new Vector3(0, -1, 0), new Vector3(0, -1, 0), new Vector3(0, -1, 0),
                    new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 1),
                    new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1),
                    new Vector3(-1, 0, 0), new Vector3(-1, 0, 0), new Vector3(-1, 0, 0), new Vector3(-1, 0, 0),
                    new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0) };
                cube.beginmode = BeginMode.Quads;
                return cube;
            }
        }
    }
}
