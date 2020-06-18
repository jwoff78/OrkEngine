using OrkEngine.Graphics.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OrkEngine.Graphics
{
    public class Material
    {
        public Texture diffuseMap;
        public Texture specularMap;
        public Vector3 specular = new Vector3(0,0,0);
        public float shininess = 32f;

        public Material()
        {
            //diffuseMap = new Texture("Graphics/Default/default.png");
            //specularMap = new Texture("Graphics/Default/blank.png");
        }
        public Material(Texture diffuse, Texture spec)
        {
            diffuseMap = diffuse;
            specularMap = spec;
            //specularMap = new Texture("Graphics/Default/blank.png");
        }
    }
}
