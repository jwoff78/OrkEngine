using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrkCore.Interface;
using System.IO;
using OrkCore.Interface;
using OpenGL;
using Vec3 = OpenGL.Vector3;

namespace Tests
{
    class Program
    {
        GameWindow gameWindow = new GameWindow();
        Renderable vcube;
        Renderable r;

        bool mode = true;
        float[] limits = {-1.5f, 1.5f};
        int[] counter = {0, 10};
        public static void Main(string[] args)
        {
            new Program();
        }
        public Program()
        {
            
        }
        public object Start()
        {
            Console.WriteLine("Start");
            /*vcube = Renderable.Cube;
            vcube.texture = new Texture("vroooom.png");
            vcube.PrepareVBOs();
            vcube.rotation = new Vec3(0.5f, 0.5f, 0);

            gameWindow.AddRenderable(vcube);*/

            r = Renderable.LoadFromFile(@"vroooomcube2.obj");
            r.PrepareVBOs();
            r.texture = new Texture(@"Cube9_auv.png");

            Console.WriteLine("ELEMENTS: " + r.elements.Length);
            Console.WriteLine("UVS: " + r.uvs.Length);

            gameWindow.AddRenderable(r);

            return null;
        }
        public object Update()
        {
            counter[0]++;

            if (counter[0] > counter[1]) {
                counter[0] = 0;

                r.rotation.x += 0.05f;
                r.rotation.y += 0.025f;

                /*vcube.rotation.x += 0.05f;
                vcube.rotation.y += 0.025f;

                if (mode)
                    vcube.position.x += (limits[1] - vcube.position.x) / 3;
                else
                    vcube.position.x += (limits[0] - vcube.position.x) / 3;

                if (vcube.position.x > 1.45f || vcube.position.x < -1.45f)
                    mode = !mode;*/
            }
            return null;
        }
    }
}
