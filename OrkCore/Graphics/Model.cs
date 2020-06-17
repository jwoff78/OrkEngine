using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OrkEngine.Graphics.Common;
using OrkEngine.Component;
using OrkEngine.Component.OBJLoader;
using OpenTK.Graphics.OpenGL4;

namespace OrkEngine.Graphics
{
    public class Model
    {
        public float[] vertices;
        public uint[] indices;
        public Vector3[] normals;
        public Texture texture = new Texture("Graphics/Default/default.png");
        public RenderMode renderMode = RenderMode.Triangles;

        public int elementBufferObject;
        public int vertexBufferObject;
        public int vertexArrayObject;

        public Model() { }
        public Model(string Name, float[] Verts, Vector3[] Normals, Texture Tex)
        {
            vertices = Verts;
            normals = Normals;
            texture = Tex;
        }

        public enum RenderMode
        {
            Triangles = PrimitiveType.Triangles,
            Quads = PrimitiveType.Quads,
            Lines = PrimitiveType.Lines
        }

        public struct Material
        {

        }

        public static Model Cube
        {
            get{
                Model cube = new Model();
                cube.vertices = new float[]
                    {
            // Positions          Normals              Texture coords
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

        public static Model LoadModelFromFile(string path)
        {
            Model rend = new Model();

            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream(path, FileMode.Open);
            var result = objLoader.Load(fileStream);

            List<Vector3> rawverts = new List<Vector3>();
            List<Vector2> rawuvs = new List<Vector2>();
            List<Vector3> rawnormals = new List<Vector3>();


            List<float> verts = new List<float>();
            List<uint> elements = new List<uint>();

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

            uint c = 0;
            foreach (Group g in result.Groups)
                foreach (Face f in g.Faces)
                    foreach (FaceVertex i in f._vertices)
                    {
                        elements.Add(c);
                        c++;

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


            rend.vertices = verts.ToArray();
            rend.indices = elements.ToArray();

            Console.WriteLine(verts.Count);

            return rend;
        }

        /*public static Model[] LoadModelsFromFile(string path)
        {
            Model rend = new Model();

            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream(path, FileMode.Open);
            var result = objLoader.Load(fileStream);

            List<Vector3> rawverts = new List<Vector3>();
            List<Vector2> rawuvs = new List<Vector2>();


            List<float> verts = new List<float>();
            List<uint> elements = new List<uint>();

            foreach (Vertex v in result.Vertices)
            {
                rawverts.Add(new Vector3(v.X, v.Y, v.Z));
            }
            foreach (Texture t in result.Textures)
            {
                rawuvs.Add(new Vector2(t.X, t.Y));
            }

            Console.WriteLine(rawverts.Count);
            Console.WriteLine(rawuvs.Count);

            uint c = 0;
            foreach (Group g in result.Groups)
                foreach (Face f in g.Faces)
                    foreach (FaceVertex i in f._vertices)
                    {
                        elements.Add(c);
                        c++;

                        verts.Add(rawverts[i.VertexIndex - 1].X);
                        verts.Add(rawverts[i.VertexIndex - 1].Y);
                        verts.Add(rawverts[i.VertexIndex - 1].Z);
                        if (rawuvs.Count > 0)
                        {
                            verts.Add(rawuvs[i.TextureIndex - 1].X);
                            verts.Add(rawuvs[i.TextureIndex - 1].Y);
                        }
                        else
                        {
                            verts.Add(0);
                            verts.Add(0);
                        }
                    }

            rend.vertices = verts.ToArray();
            rend.indices = elements.ToArray();

            Console.WriteLine(verts.Count);

            return rend;
        }*/
    }
}
