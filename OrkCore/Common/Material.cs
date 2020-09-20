using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OrkEngine
{
    public class Material
    {
        public Texture DiffuseMap;
        public Texture SpecularMap;
        public Vector3 Specular = new Vector3(0,0,0);
        public float Shininess = 32f;

        public Material()
        {
            //diffuseMap = new Texture("Graphics/Default/default.png");
            //specularMap = new Texture("Graphics/Default/blank.png");
        }
        public Material(Texture diffuse, Texture spec)
        {
            DiffuseMap = diffuse;
            SpecularMap = spec;
            //specularMap = new Texture("Graphics/Default/blank.png");
        }
    }
}
