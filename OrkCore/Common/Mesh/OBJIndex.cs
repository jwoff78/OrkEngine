using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class OBJIndex : IEquatable<OBJIndex>
    {
        private int m_vertexIndex;
        private int m_texCoordIndex;
        private int m_normalIndex;

        public int VertexIndex
        {
            get
            {
                return m_vertexIndex;
            }
            set
            {
                m_vertexIndex = value;
            }
        }

        public int TexCoordIndex
        {
            get
            {
                return m_texCoordIndex;
            }
            set
            {
                m_texCoordIndex = value;
            }
        }

        public int NormalIndex
        {
            get
            {
                return m_normalIndex;
            }
            set
            {
                m_normalIndex = value;
            }
        }

        public bool Equals(OBJIndex other)
        {
            OBJIndex index = (OBJIndex)other;

            return m_vertexIndex   == index.m_vertexIndex
                && m_texCoordIndex == index.m_texCoordIndex
                && m_normalIndex   == index.m_normalIndex;
        }

        public bool Equals(object other)
        {
            OBJIndex index = (OBJIndex)other;

            return m_vertexIndex   == index.m_vertexIndex
                && m_texCoordIndex == index.m_texCoordIndex
                && m_normalIndex   == index.m_normalIndex;
        }

        public override int GetHashCode()
        {
            int BASE = 17;
            int MULTIPLIER = 31;

            int result = BASE;

            result = MULTIPLIER * result + m_vertexIndex;
            result = MULTIPLIER * result + m_texCoordIndex;
            result = MULTIPLIER * result + m_normalIndex;

            return result;
        }
    }
}
