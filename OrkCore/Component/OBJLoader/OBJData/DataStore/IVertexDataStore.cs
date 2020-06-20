using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.OBJLoader
{
    public interface IVertexDataStore
    {
        void AddVertex(Vertex vertex);
    }
}
