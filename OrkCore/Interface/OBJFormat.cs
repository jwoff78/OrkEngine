using JJGECore.Mathematics;
using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJGE_Core.Interface
{
    public class Renderable
    {
        public string name = "OBJECT";
        private static VBO<OpenGL.Vector3> vertices;
        private static VBO<uint> tris;
        private static VBO<OpenGL.Vector2> uv;
        private static VBO<OpenGL.Vector3> normals;
        private static Texture texture;

        public Renderable()
        {

        }
    }
}
