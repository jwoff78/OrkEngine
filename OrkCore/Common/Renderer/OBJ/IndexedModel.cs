using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Common.Renderer.OBJ
{
    public class IndexedModel
    {
        private List<Vector3f> m_positions;
        private List<Vector2f> m_texCoords;
        private List<Vector3f> m_normals;
        private List<Vector3f> m_tangents;
        private List<int>  m_indices;

        public IndexedModel()
        {
            m_positions = new List<Vector3f>();
            m_texCoords = new List<Vector2f>();
            m_normals = new List<Vector3f>();
            m_tangents = new List<Vector3f>();
            m_indices = new List<int>();
        }

        public void CalculateNormals()
        {
            
        }

        public void CalculateTangents()
        {

        }
    }
}
