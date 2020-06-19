using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OrkEngine.Component.OBJLoader;
using OrkEngine.Component;
using OrkEngine.Graphics.Common;
using System.IO;
using OpenTK.Graphics.ES11;
using BEPUphysics;
using BEPUphysics.BroadPhaseEntries;
using numVec3 = System.Numerics.Vector3;

namespace OrkEngine.Graphics
{
    public class Model
    {
        public Mesh[] meshes;
        public RenderMode renderMode = RenderMode.Triangles;

        public Model() { }
        public Model(Mesh m)
        {
            meshes = new Mesh[1];
            meshes[0] = m;
        }

        public Model(Mesh[] m)
        {
            meshes = m;
        }
        public enum RenderMode
        {
            Triangles = PrimitiveType.Triangles,
            Quads = PrimitiveType.Quads,
            Lines = PrimitiveType.Lines
        }

        public static Model Cube
        {
            get
            {
                Model c = new Model();
                c.meshes = new Mesh[] { Mesh.Cube };
                c.meshes[0].material = new Material(new Texture("Graphics/Default/default.png"), new Texture("Graphics/Default/blank.png"));
                return c;
            }
        }
        public static Model Plane
        {
            get
            {
                Model c = new Model();
                c.meshes = new Mesh[] { Mesh.Plane };
                c.meshes[0].material = new Material(new Texture("Graphics/Default/default.png"), new Texture("Graphics/Default/blank.png"));
                return c;
            }
        }

        public static Model LoadModelFromFile(string obj)
        {
            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream(obj, FileMode.Open);
            var result = objLoader.Load(fileStream);

            Texture def = new Texture("Graphics/Default/default.png");
            Texture blank = new Texture("Graphics/Default/blank.png");

            List<Mesh> meshlist = new List<Mesh>();

            List<Vector3> rawverts = new List<Vector3>();
            List<Vector2> rawuvs = new List<Vector2>();
            List<Vector3> rawnormals = new List<Vector3>();

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
                rawuvs.Add(new Vector2(t.X, t.Y));
            }

            Console.WriteLine(rawverts.Count);
            Console.WriteLine(rawuvs.Count);

            foreach (Group g in result.Groups)
            {
                Mesh m = new Mesh();
                Material mm = new Material();

                string diffmap = g.Material.DiffuseTextureMap;
                string specmap = g.Material.SpecularTextureMap;

                Console.WriteLine("DIFF - '" + diffmap + "'  SPEC - '" + specmap + "'");

                if (diffmap.IsNullOrEmpty())
                    mm.diffuseMap = def;
                else
                    mm.diffuseMap = new Texture(Directory.GetCurrentDirectory() + diffmap);

                if (specmap.IsNullOrEmpty())
                    mm.specularMap = blank;
                else
                    mm.specularMap = new Texture(Directory.GetCurrentDirectory() + specmap);

                List<float> VoxelData = new List<float>();

                foreach (Face f in g.Faces)
                    foreach (FaceVertex i in f._vertices)
                    {

                        VoxelData.Add(rawverts[i.VertexIndex - 1].X);
                        VoxelData.Add(rawverts[i.VertexIndex - 1].Y);
                        VoxelData.Add(rawverts[i.VertexIndex - 1].Z);

                        if (rawnormals.Count > 0)
                        {
                            VoxelData.Add(rawnormals[i.NormalIndex - 1].X);
                            VoxelData.Add(rawnormals[i.NormalIndex - 1].Y);
                            VoxelData.Add(rawnormals[i.NormalIndex - 1].Z);
                        }

                        if (rawuvs.Count > 0)
                        {
                            VoxelData.Add(rawuvs[i.TextureIndex - 1].X);
                            VoxelData.Add(rawuvs[i.TextureIndex - 1].Y);
                        }
                        else
                        {
                            VoxelData.Add(0);
                            VoxelData.Add(0);
                        }
                    }
                m.material = mm;
                m.vertices = VoxelData.ToArray();
                meshlist.Add(m);
            }

            Model mod = new Model(meshlist.ToArray());

            return mod;
        }
        public static StaticMesh ConvertToStaticMesh(Model mod)
        {
            StaticMesh sm;
            List<numVec3> verts = new List<numVec3>();
            List<int> indices = new List<int>();

            int count = 0;
            foreach (Mesh m in mod.meshes) 
            {
                count++;
                for (int i = 0; i < m.vertices.Length / 8; i++)
                {
                    verts.Add(new numVec3(m.vertices[i], m.vertices[i + 1], m.vertices[i + 2]));
                    indices.Add(i);
                }
                Console.WriteLine("Translated Mesh {0} / {1}", count, mod.meshes.Length);
            }
            numVec3[] v = verts.ToArray();
            int[] ii = indices.ToArray();
            sm = new StaticMesh(v,ii);
            Console.WriteLine("Done");

            return sm;
        }
        public static numVec3[] getPoints(Model mod)
        {
            List<numVec3> verts = new List<numVec3>();

            foreach (Mesh m in mod.meshes)
            {
                for (int i = 0; i < m.vertices.Length / 8; i++)
                {
                    verts.Add(new numVec3(m.vertices[i], m.vertices[i + 1], m.vertices[i + 2]));
                }
            }
            numVec3[] v = verts.ToArray();

            return v;
        }
    }
}
