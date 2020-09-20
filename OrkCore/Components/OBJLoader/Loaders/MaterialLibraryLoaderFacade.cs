using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Components.OBJLoader
{
    public class MaterialLibraryLoaderFacade : IMaterialLibraryLoaderFacade
    {
        private readonly IMaterialLibraryLoader _loader;
        private readonly IMaterialStreamProvider _materialStreamProvider;

        public MaterialLibraryLoaderFacade(IMaterialLibraryLoader loader, IMaterialStreamProvider materialStreamProvider)
        {
            _loader = loader;
            _materialStreamProvider = materialStreamProvider;
        }

        public void Load(string materialFileName)
        {
            using (var stream = _materialStreamProvider.Open(materialFileName))
            {
                if (stream != null)
                {
                    _loader.Load(stream);
                }
            }
        }
    }
}
