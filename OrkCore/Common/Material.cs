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
        protected Texture m_diffuseMap;
        protected Texture m_specularMap;
        protected float m_shininess = 32f;

       // public Vector3 Diffuse = new Vector3(0, 0, 0);
       // public Vector3 Specular = new Vector3(0, 0, 0);

        public Texture DiffuseMap
        { 
            get
            {
                return m_diffuseMap;
            }
            set
            {
                m_diffuseMap = value;
            }
        }

        public Texture SpecularMap
        {
            get
            {
                return m_specularMap;
            }
            set
            {
                m_specularMap = value;
            }
        }

        public float Shininess
        {
            get
            {
                return m_shininess;
            }

            set
            {
                m_shininess = value;
            }
        }

        public Vector3 Diffuse
        {

            get; set;

        } = new Vector3(0, 0, 0);

        public Vector3 Specular
        {

            get; set;

        } = new Vector3(0, 0, 0);

        public Material()
        {
            //diffuseMap = new Texture("Graphics/Default/default.png");
            //specularMap = new Texture("Graphics/Default/blank.png");
        }
        public Material(Texture diffuse, Texture specular)
        {
            DiffuseMap = diffuse;
            SpecularMap = specular;
            //specularMap = new Texture("Graphics/Default/blank.png");
        }
    }
}
