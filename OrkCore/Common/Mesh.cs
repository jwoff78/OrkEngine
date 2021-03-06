﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace OrkEngine
{
    
    public class Mesh
    {
        public float[] m_vertices;
        public Material Material = new Material();

        public int ElementBufferObject;
        public int VertexBufferObject;
        public int VertexArrayObject;

        public Mesh() { }
        public Mesh(string name, float[] verts, Material mat)
        {
            m_vertices = verts;
            Material = mat;
        }

        public static Mesh Cube
        {
            get{
                Mesh cube = new Mesh();
                cube.m_vertices = new float[]{
                    -0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 0.0f,
                     0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 0.0f,
                     0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 1.0f,
                     0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 1.0f,
                    -0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 1.0f,
                    -0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 0.0f,

                    -0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  0.0f, 0.0f,
                     0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  1.0f, 0.0f,
                     0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  1.0f, 1.0f,
                     0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  1.0f, 1.0f,
                    -0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  0.0f, 1.0f,
                    -0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  0.0f, 0.0f,

                    -0.5f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 0.0f,
                    -0.5f,  0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 1.0f,
                    -0.5f, -0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
                    -0.5f, -0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
                    -0.5f, -0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 0.0f,
                    -0.5f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 0.0f,

                     0.5f,  0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 0.0f,
                     0.5f,  0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 1.0f,
                     0.5f, -0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
                     0.5f, -0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
                     0.5f, -0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 0.0f,
                     0.5f,  0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 0.0f,

                    -0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 1.0f,
                     0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 1.0f,
                     0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 0.0f,
                     0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 0.0f,
                    -0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 0.0f,
                    -0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 1.0f,

                    -0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f,
                     0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 1.0f,
                     0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
                     0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
                    -0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
                    -0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f
                };
                //Console.WriteLine(cube.vertices.Length);
                return cube;
            }
        }

        public static Mesh Plane
        {
            get
            {
                Mesh cube = new Mesh();
                cube.m_vertices = new float[]{
                    -1.0f,  0.0f, -1.0f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f,
                     1.0f,  0.0f, -1.0f,  0.0f,  1.0f,  0.0f,  1.0f, 1.0f,
                     1.0f,  0.0f,  1.0f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
                     1.0f,  0.0f,  1.0f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
                    -1.0f,  0.0f,  1.0f,  0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
                    -1.0f,  0.0f, -1.0f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f
                };
                //Console.WriteLine(cube.vertices.Length);
                return cube;
            }
        }
        /*
        public static Mesh LoadMeshFromFile(string path)
        {
            Mesh rend = new Mesh();

            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream(path, FileMode.Open);
            var result = objLoader.Load(fileStream);

            List<Vector3> rawverts = new List<Vector3>();
            List<Vector2> rawuvs = new List<Vector2>();
            List<Vector3> rawnormals = new List<Vector3>();


            List<float> verts = new List<float>();

            foreach (Vertex v in result.Vertices)
            {
                rawverts.Add(new Vector3(v.X, v.Y, v.Z));
            }
            foreach (Normal n in result.Normals)
            {
                rawnormals.Add(new Vector3(n.X, n.Y, n.Z));
            }
            foreach (Texture t in result.Textures)
            {
                rawuvs.Add(new Vector2(t.X,t.Y));
            }

            Console.WriteLine(rawverts.Count);
            Console.WriteLine(rawuvs.Count);

            foreach (Group g in result.Groups)
                foreach (Face f in g.Faces)
                    foreach (FaceVertex i in f._vertices)
                    {

                        verts.Add(rawverts[i.VertexIndex-1].X);
                        verts.Add(rawverts[i.VertexIndex-1].Y);
                        verts.Add(rawverts[i.VertexIndex-1].Z);

                        if (rawnormals.Count > 0)
                        {
                            verts.Add(rawnormals[i.NormalIndex - 1].X);
                            verts.Add(rawnormals[i.NormalIndex - 1].Y);
                            verts.Add(rawnormals[i.NormalIndex - 1].Z);
                        }

                        if (rawuvs.Count > 0) {
                            verts.Add(rawuvs[i.TextureIndex - 1].X);
                            verts.Add(rawuvs[i.TextureIndex - 1].Y);
                        }
                        else
                        {
                            verts.Add(0);
                            verts.Add(0);
                        }
                    }


            rend.m_vertices = verts.ToArray();

            Console.WriteLine(verts.Count);

            return rend;
        }*/

        public Vector3[] Vertices
        {
            get; set;
        }

        public Vector3[] Normals
        {
            get; set;
        }

        public Vector2[] UV
        {
            get; set;
        }

    }
}
