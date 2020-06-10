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
        Func<object> Start;
        Func<object> Update;

        public GameWindow(Func<object> start, Func<object> update, string title = "OrkRender", int w = 1280, int h = 720)
        {
            winWidth = w;
            winHeight = h;
            Title = title;
            Start = start;
            Update = update;

            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("SDL ded ono [ERROR: '{0}']", SDL.SDL_GetError());
                return;
            }

            var window = SDL.SDL_CreateWindow(Title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, winWidth, winHeight, SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);

            var renderer = SDL.SDL_CreateRenderer(window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

            var Image = SDL_image.IMG_LoadTexture(renderer, "ork_engine.png");



            #region ork
            SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);
            SDL.SDL_RenderClear(renderer);

            SDL.SDL_Rect r1;
            r1.x = 0;
            r1.y = 0;
            r1.w = 200;
            r1.h = 200;

            SDL.SDL_Rect r2;
            r2.x = 450;
            r2.y = 150;
            r2.w = 400;
            r2.h = 400;

            SDL.SDL_RenderCopy(renderer, Image, ref r1, ref r2);

            SDL.SDL_RenderPresent(renderer);
            #endregion

            SDL.SDL_Event e;
            bool quit = false;

            Start();

            /* MAIN LOOP */

            while (!quit)
            {
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                            quit = true;
                            break;
                    }
                }
                Update();
            }
            SDL.SDL_DestroyTexture(Image);
            SDL.SDL_DestroyRenderer(renderer);
            SDL.SDL_DestroyWindow(window);

            SDL.SDL_Quit();
        }
    }
}
