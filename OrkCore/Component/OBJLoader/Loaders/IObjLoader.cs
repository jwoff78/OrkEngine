﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Component.OBJLoader
{
    public interface IObjLoader
    {
        LoadResult Load(Stream lineStream);
    }
}
