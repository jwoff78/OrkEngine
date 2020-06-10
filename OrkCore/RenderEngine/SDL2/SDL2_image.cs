#region License
/* SDL2# - C# Wrapper for SDL2
 *
 * Copyright (c) 2013 Ethan Lee.
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Ethan "flibitijibibo" Lee <flibitijibibo@flibitijibibo.com>
 *
 */
#endregion

#region Using Statements
using System;
using System.Runtime.InteropServices;
#endregion

namespace OrkEngine.Rendering
{
	public static class SDL_image
	{
		#region SDL2# Variables
		
		/* Used by DllImport to load the native library. */
		private const string nativeLibName = "SDL2_image.dll";
		
		#endregion
		
		#region SDL_image.h
		
		[Flags]
		public enum IMG_InitFlags
		{
			IMG_INIT_JPG =	0x00000001,
			IMG_INIT_PNG =	0x00000002,
			IMG_INIT_TIF =	0x00000004,
			IMG_INIT_WEBP =	0x00000008
		}
		
		[DllImport(nativeLibName, EntryPoint = "IMG_LinkedVersion")]
		private static extern IntPtr INTERNAL_IMG_LinkedVersion();
		public static SDL.SDL_version IMG_LinkedVersion()
		{
			SDL.SDL_version result = new SDL.SDL_version();
			IntPtr result_ptr = INTERNAL_IMG_LinkedVersion();
			result = (SDL.SDL_version) Marshal.PtrToStructure(
				result_ptr,
				result.GetType()
			);
			return result;
		}
		
		[DllImport(nativeLibName)]
		public static extern int IMG_Init(IMG_InitFlags flags);
		
		[DllImport(nativeLibName)]
		public static extern void IMG_Quit();
		
		/* IntPtr refers to an SDL_Surface* */
		[DllImport(nativeLibName)]
		public static extern IntPtr IMG_Load(
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string file
		);
		
		/* IntPtr refers to an SDL_Texture*, renderer to an SDL_Renderer* */
		[DllImport(nativeLibName)]
		public static extern IntPtr IMG_LoadTexture(
			IntPtr renderer,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string file
		);
		
		[DllImport(nativeLibName)]
		public static extern int IMG_InvertAlpha(int on);
		
		/* IntPtr refers to an SDL_Surface* */
		[DllImport(nativeLibName)]
		public static extern IntPtr IMG_ReadXPMFromArray(ref char[] xpm);
		
		#endregion
	}
}
