using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Component.OBJLoader
{
    public interface IGroupDataStore
    {
        void PushGroup(string groupName);
    }
}
