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

namespace SDL2
{
	public static class SDL_ttf
	{
		#region SDL2# Variables
		
		/* Used by DllImport to load the native library. */
		private const string nativeLibName = "SDL2_ttf.dll";
		
		#endregion
		
		#region SDL_ttf.h
		
		public const int UNICODE_BOM_NATIVE =	0xFEFF;
		public const int UNICODE_BOM_SWAPPED =	0xFFFE;
		
		public const int TTF_STYLE_NORMAL =		0x00;
		public const int TTF_STYLE_BOLD =		0x01;
		public const int TTF_STYLE_ITALIC =		0x02;
		public const int TTF_STYLE_UNDERLINE =		0x04;
		public const int TTF_STYLE_STRIKETHROUGH =	0x08;
		
		public const int TTF_HINTING_NORMAL =	0;
		public const int TTF_HINTING_LIGHT =	1;
		public const int TTF_HINTING_MONO =	2;
		public const int TTF_HINTING_NONE =	3;
		
		[DllImport(nativeLibName, EntryPoint = "TTF_LinkedVersion")]
		private static extern IntPtr INTERNAL_TTF_LinkedVersion();
		public static SDL.SDL_version TTF_LinkedVersion()
		{
			SDL.SDL_version result = new SDL.SDL_version();
			IntPtr result_ptr = INTERNAL_TTF_LinkedVersion();
			result = (SDL.SDL_version) Marshal.PtrToStructure(
				result_ptr,
				result.GetType()
			);
			return result;
		}
		
		[DllImport(nativeLibName)]
		public static extern void TTF_ByteSwappedUNICODE(int swapped);
		
		[DllImport(nativeLibName)]
		public static extern int TTF_Init();
		
		/* IntPtr refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_OpenFont(
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string file,
			int ptsize
		);
		
		/* IntPtr refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_OpenFontIndex(
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string file,
			int ptsize,
			long index
		);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_GetFontStyle(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern void TTF_SetFontStyle(IntPtr font, int style);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_GetFontOutline(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern void TTF_SetFontOutline(IntPtr font, int outline);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_GetFontHinting(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern void TTF_SetFontHinting(IntPtr font, int hinting);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_FontHeight(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_FontAscent(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_FontDescent(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_FontLineSkip(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_GetFontKerning(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern void TTF_SetFontKerning(IntPtr font, int allowed);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern long TTF_FontFaces(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_FontFaceIsFixedWidth(IntPtr font);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName, EntryPoint = "TTF_FontFaceFamilyName")]
		private static extern IntPtr INTERNAL_TTF_FontFaceFamilyName(
			IntPtr font
		);
		public static string TTF_FontFaceFamily(IntPtr font)
		{
			return Marshal.PtrToStringAnsi(
				INTERNAL_TTF_FontFaceFamilyName(font)
			);
		}
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName, EntryPoint = "TTF_FontFaceStyleName")]
		private static extern IntPtr INTERNAL_TTF_FontFaceStyleName(
			IntPtr font
		);
		public static string TTF_FontFaceStyleName(IntPtr font)
		{
			return Marshal.PtrToStringAnsi(
				INTERNAL_TTF_FontFaceStyleName(font)
			);
		}
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_GlyphIsProvided(IntPtr font, ushort ch);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_GlyphMetrics(
			IntPtr font,
			ushort ch,
			ref int minx,
			ref int maxx,
			ref int miny,
			ref int maxy,
			ref int advance
		);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_SizeText(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			ref int w,
			ref int h
		);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_SizeUTF8(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			ref int w,
			ref int h
		);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int TTF_SizeUNICODE(
			IntPtr font,
			ushort[] text,
			ref int w,
			ref int h
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderText_Solid(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderUTF8_Solid(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderUNICODE_Solid(
			IntPtr font,
			ushort[] text,
			SDL.SDL_Color fg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderGlyph_Solid(
			IntPtr font,
			ushort ch,
			SDL.SDL_Color fg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderText_Shaded(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderUTF8_Shaded(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderUNICODE_Shaded(
			IntPtr font,
			ushort[] text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderGlyph_Shaded(
			IntPtr font,
			ushort ch,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderText_Blended(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderUTF8_Blended(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderUNICODE_Blended(
			IntPtr font,
			ushort[] text,
			SDL.SDL_Color fg
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderText_Blended_Wrapped(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg,
			uint wrapped
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderUTF8_Blended_Wrapped(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg,
			uint wrapped
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderUNICODE_Blended_Wrapped(
			IntPtr font,
			ushort[] text,
			SDL.SDL_Color fg,
			uint wrapped
		);
		
		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern IntPtr TTF_RenderGlyph_Blended(
			IntPtr font,
			ushort ch,
			SDL.SDL_Color fg
		);
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern void TTF_CloseFont(IntPtr font);
		
		[DllImport(nativeLibName)]
		public static extern void TTF_Quit();
		
		[DllImport(nativeLibName)]
		public static extern int TTF_WasInit();
		
		/* font refers to a TTF_Font* */
		[DllImport(nativeLibName)]
		public static extern int SDL_GetFontKerningSize(
			IntPtr font,
			int prev_index,
			int index
		);
		
		#endregion
	}
}
