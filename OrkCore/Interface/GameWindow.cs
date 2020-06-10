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

            Console.WriteLine("Hello, Mother Fucker");

            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            var window = SDL.SDL_CreateWindow(Title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, winWidth, winHeight, SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);

            SDL.SDL_Delay(5000);
            SDL.SDL_DestroyWindow(window);

            SDL.SDL_Quit();
        }
    }
}
