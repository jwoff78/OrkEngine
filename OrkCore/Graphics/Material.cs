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
            Material dm = defaultMat;
            diffuseMap = dm.diffuseMap;
            specularMap = dm.specularMap;
        }
        public Material(Texture diffuse, Texture spec)
        {
            diffuseMap = diffuse;
            specularMap = spec;
            //specularMap = new Texture("Graphics/Default/blank.png");
        }
        public static Material defaultMat
        {
            get
            {
                Material m = new Material(new Texture("Graphics/Default/default.png"), new Texture("Graphics/Default/blank.png"));
                return m;
            }
        }
    }
}
