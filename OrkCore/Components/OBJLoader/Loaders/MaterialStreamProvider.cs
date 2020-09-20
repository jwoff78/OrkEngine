using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Components.OBJLoader
{
    public class MaterialStreamProvider : IMaterialStreamProvider
    {
        public Stream Open(string materialFilePath)
        {
            return File.Open(materialFilePath, FileMode.Open, FileAccess.Read);
        }
    }
}
