//using OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SDL2;

namespace OrkEngine.Interface
{
    public class GameWindow
    {
        string Title;
        int winWidth = 1600, winHeight = 900;
        bool closed = false;

        public GameWindow(string title = "OrkRender", int w = 1600, int h = 900)
        {
            winWidth = w;
            winHeight = h;
            Title = title;

            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
            SDL.SDL_Quit();
        }
    }
}
