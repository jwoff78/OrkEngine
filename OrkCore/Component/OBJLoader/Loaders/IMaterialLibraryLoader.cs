using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.OBJLoader
{
    public interface IMaterialLibraryLoader
    {
        void Load(Stream lineStream);
    }
}
