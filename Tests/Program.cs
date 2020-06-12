using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OrkEngine.Graphics;
using OrkEngine.Graphics.Common;
using OpenTK.Input;
using OrkEngine.Interface.UI.Core;
using System.Runtime.ConstrainedExecution;
using OrkEngine;

namespace Tests
{
    public class Program : IOrkEngine
    {
        
       

        public static void Main(string[] args)
        {
            new Program();
        }

        public Program() {
            Init();
        }

     
    }
}
