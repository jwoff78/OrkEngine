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

        protected string m_vertexPath;
        protected string m_fragmentPath;

        public Vector3 Diffuse = new Vector3(0, 0, 0);
        public Vector3 Specular = new Vector3(0, 0, 0);
        public float Shininess = 32f;

        public Shader GetShader()
        {
            return new Shader(VertexPath, FragmentPath);
        }
        
        public Shader GetShader(string vertexPath, string fragmentPath)
        {
            VertexPath = vertexPath;
            FragmentPath = fragmentPath;
            return new Shader(vertexPath, fragmentPath);
        }

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

        public string VertexPath
        {
            get
            {
                return m_vertexPath;
            }
            set
            {
                m_vertexPath = value;
            }
        }

        public string FragmentPath
        {
            get
            {
                return m_fragmentPath;
            }
            set
            {
                m_fragmentPath = value;
            }
        }

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
