using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
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
            for (int i = 0; i < m_indices.Count(); i += 3)
            {
                int i0 = m_indices[i];
                int i1 = m_indices[i + 1];
                int i2 = m_indices[i + 2];

                Vector3f v1 = m_positions[i1].Sub(m_positions[i0]);
                Vector3f v2 = m_positions[i2].Sub(m_positions[i0]);

                Vector3f normal = v1.Cross(v2).Normalized();

                m_normals[i0].Set(m_normals[i0].Add(normal));
                m_normals[i1].Set(m_normals[i1].Add(normal));
                m_normals[i2].Set(m_normals[i2].Add(normal));
            }

            for (int i = 0; i < m_normals.Count(); i++)
                m_normals[i].Set(m_normals[i].Normalized());
        }

        public void CalculateTangents()
        {
            for (int i = 0; i < m_indices.Count(); i += 3)
            {
                int i0 = m_indices[i];
                int i1 = m_indices[i + 1];
                int i2 = m_indices[i + 2];

                Vector3f edge1 = m_positions[i1].Sub(m_positions[i0]);
                Vector3f edge2 = m_positions[i2].Sub(m_positions[i0]);

                float deltaU1 = m_texCoords[i1].X - m_texCoords[i0].X;
                float deltaV1 = m_texCoords[i1].Y - m_texCoords[i0].Y;
                float deltaU2 = m_texCoords[i2].X - m_texCoords[i0].X;
                float deltaV2 = m_texCoords[i2].Y - m_texCoords[i0].Y;

                float dividend = (deltaU1*deltaV2 - deltaU2*deltaV1);
                //TODO: The first 0.0f may need to be changed to 1.0f here.
                float f = dividend == 0 ? 0.0f : 1.0f/dividend;

                Vector3f tangent = new Vector3f(0,0,0);
                tangent.X = (f * ( deltaV2 * edge1.X - deltaV1 * edge2.X ));
                tangent.Y = (f * ( deltaV2 * edge1.Y - deltaV1 * edge2.Y ));
                tangent.Z = (f * ( deltaV2 * edge1.Z - deltaV1 * edge2.Z ));

                m_tangents[i0].Set(m_tangents[i0].Add(tangent));
                m_tangents[i1].Set(m_tangents[i1].Add(tangent));
                m_tangents[i2].Set(m_tangents[i2].Add(tangent));
            }

            for (int i = 0; i < m_tangents.Count(); i++)
                m_tangents[i].Set(m_tangents[i].Normalized());
        }

        public List<Vector3f> Positions
        {
            get
            {
                return m_positions;
            }
        }

        public List<Vector2f> TexCoords
        {
            get
            {
                return m_texCoords;
            }
        }

        public List<Vector3f> Normals
        {
            get
            {
                return m_normals;
            }
        }

        public List<Vector3f> Tangents
        {
            get
            {
                return m_tangents;
            }
        }

        public List<int> Indices
        {
            get
            {
                return m_indices;
            }
        }
    }
}
