using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Components.OBJLoader
{
    public class Face
    {
        public readonly List<FaceVertex> _vertices = new List<FaceVertex>();

        public void AddVertex(FaceVertex vertex)
        {
            _vertices.Add(vertex);
        }

        public FaceVertex this[int i]
        {
            get { return _vertices[i]; }
        }

        public int Count
        {
            get { return _vertices.Count; }
        }
    }

    public struct FaceVertex : IEquatable<FaceVertex>
    {
        public FaceVertex(int vertexIndex, int textureIndex, int normalIndex) : this()
        {
            VertexIndex = vertexIndex;
            TextureIndex = textureIndex;
            NormalIndex = normalIndex;
        }

        public int VertexIndex { get; set; }
        public int TextureIndex { get; set; }
        public int NormalIndex { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is FaceVertex faceVertex))
                return false;

            return this.VertexIndex == faceVertex.VertexIndex &&
                   this.TextureIndex == faceVertex.TextureIndex &&
                   this.NormalIndex == faceVertex.NormalIndex;
        }

        public override int GetHashCode()
        {
            return VertexIndex.GetHashCode() + TextureIndex.GetHashCode() + NormalIndex.GetHashCode();
        }

        public static bool operator ==(FaceVertex left, FaceVertex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FaceVertex left, FaceVertex right)
        {
            return !(left == right);
        }

        public bool Equals(FaceVertex other)
        {
            if (!(other is FaceVertex faceVertex))
                return false;

            return this.VertexIndex == faceVertex.VertexIndex &&
                   this.TextureIndex == faceVertex.TextureIndex &&
                   this.NormalIndex == faceVertex.NormalIndex;
        }
    }
}
