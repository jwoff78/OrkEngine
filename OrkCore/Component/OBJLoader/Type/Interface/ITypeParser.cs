﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkCore.Component.OBJLoader
{
    public interface ITypeParser
    {
        bool CanParse(string keyword);
        void Parse(string line);
    }
}
