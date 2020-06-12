﻿using OrkEngine.Graphics.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Component.OBJLoader
{
    public interface ITextureDataStore
    {
        void AddTexture(Texture texture);
    }
}
