using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;
namespace OrkEngine
{
    public class Input
    {
		public static void Update()
        {

        }

		public static bool GetKeyDown(Key keyCode)
        {
            return Keyboard.GetState().IsKeyDown(keyCode);
        }

        public static bool GetKeyUp(Key keyCode)
        {
            return Keyboard.GetState().IsKeyUp(keyCode);
        }

        public static bool GetMouseDown(MouseButton mouseButton)
        {
            return Mouse.GetState().IsButtonDown(mouseButton);         
        }

        public static bool GetMouseUp(MouseButton mouseButton)
        {
            return Mouse.GetState().IsButtonUp(mouseButton);
        }

        public static Vector2f GetMousePosition()
        {
            return new Vector2f(Mouse.GetState().X, Mouse.GetState().Y);
        }

        public static void SetMousePosition(Vector2f pos)
        {
            Mouse.SetPosition(pos.X, pos.Y);
        }

        public static void SetCursor(bool enabled)
        {
            
        }
	}
}
