#region License
//
// The Open Toolkit Library License
//
// Copyright (c) 2006 - 2009 the Open Toolkit library.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to 
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//
#endregion

namespace OrkEngine.Rendering.Graphics.ES11
{
    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    #pragma warning disable 3019
    #pragma warning disable 1591

    partial class GL
    {

        internal static partial class Core
        {

            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glActiveTexture", ExactSpelling = true)]
            internal extern static void ActiveTexture(OrkEngine.Rendering.Graphics.ES11.All texture);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glAlphaFunc", ExactSpelling = true)]
            internal extern static void AlphaFunc(OrkEngine.Rendering.Graphics.ES11.All func, Single @ref);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glAlphaFuncx", ExactSpelling = true)]
            internal extern static void AlphaFuncx(OrkEngine.Rendering.Graphics.ES11.All func, int @ref);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glAlphaFuncxOES", ExactSpelling = true)]
            internal extern static void AlphaFuncxOES(OrkEngine.Rendering.Graphics.ES11.All func, int @ref);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBindBuffer", ExactSpelling = true)]
            internal extern static void BindBuffer(OrkEngine.Rendering.Graphics.ES11.All target, UInt32 buffer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBindFramebufferOES", ExactSpelling = true)]
            internal extern static void BindFramebufferOES(OrkEngine.Rendering.Graphics.ES11.All target, UInt32 framebuffer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBindRenderbufferOES", ExactSpelling = true)]
            internal extern static void BindRenderbufferOES(OrkEngine.Rendering.Graphics.ES11.All target, UInt32 renderbuffer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBindTexture", ExactSpelling = true)]
            internal extern static void BindTexture(OrkEngine.Rendering.Graphics.ES11.All target, UInt32 texture);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBlendEquationOES", ExactSpelling = true)]
            internal extern static void BlendEquationOES(OrkEngine.Rendering.Graphics.ES11.All mode);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBlendEquationSeparateOES", ExactSpelling = true)]
            internal extern static void BlendEquationSeparateOES(OrkEngine.Rendering.Graphics.ES11.All modeRGB, OrkEngine.Rendering.Graphics.ES11.All modeAlpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBlendFunc", ExactSpelling = true)]
            internal extern static void BlendFunc(OrkEngine.Rendering.Graphics.ES11.All sfactor, OrkEngine.Rendering.Graphics.ES11.All dfactor);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBlendFuncSeparateOES", ExactSpelling = true)]
            internal extern static void BlendFuncSeparateOES(OrkEngine.Rendering.Graphics.ES11.All srcRGB, OrkEngine.Rendering.Graphics.ES11.All dstRGB, OrkEngine.Rendering.Graphics.ES11.All srcAlpha, OrkEngine.Rendering.Graphics.ES11.All dstAlpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBufferData", ExactSpelling = true)]
            internal extern static void BufferData(OrkEngine.Rendering.Graphics.ES11.All target, IntPtr size, IntPtr data, OrkEngine.Rendering.Graphics.ES11.All usage);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glBufferSubData", ExactSpelling = true)]
            internal extern static void BufferSubData(OrkEngine.Rendering.Graphics.ES11.All target, IntPtr offset, IntPtr size, IntPtr data);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glCheckFramebufferStatusOES", ExactSpelling = true)]
            internal extern static OrkEngine.Rendering.Graphics.ES11.All CheckFramebufferStatusOES(OrkEngine.Rendering.Graphics.ES11.All target);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClear", ExactSpelling = true)]
            internal extern static void Clear(UInt32 mask);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClearColor", ExactSpelling = true)]
            internal extern static void ClearColor(Single red, Single green, Single blue, Single alpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClearColorx", ExactSpelling = true)]
            internal extern static void ClearColorx(int red, int green, int blue, int alpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClearColorxOES", ExactSpelling = true)]
            internal extern static void ClearColorxOES(int red, int green, int blue, int alpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClearDepthf", ExactSpelling = true)]
            internal extern static void ClearDepthf(Single depth);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClearDepthfOES", ExactSpelling = true)]
            internal extern static void ClearDepthfOES(Single depth);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClearDepthx", ExactSpelling = true)]
            internal extern static void ClearDepthx(int depth);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClearDepthxOES", ExactSpelling = true)]
            internal extern static void ClearDepthxOES(int depth);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClearStencil", ExactSpelling = true)]
            internal extern static void ClearStencil(Int32 s);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClientActiveTexture", ExactSpelling = true)]
            internal extern static void ClientActiveTexture(OrkEngine.Rendering.Graphics.ES11.All texture);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClipPlanef", ExactSpelling = true)]
            internal extern static unsafe void ClipPlanef(OrkEngine.Rendering.Graphics.ES11.All plane, Single* equation);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClipPlanefIMG", ExactSpelling = true)]
            internal extern static unsafe void ClipPlanefIMG(OrkEngine.Rendering.Graphics.ES11.All p, Single* eqn);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClipPlanefOES", ExactSpelling = true)]
            internal extern static unsafe void ClipPlanefOES(OrkEngine.Rendering.Graphics.ES11.All plane, Single* equation);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClipPlanex", ExactSpelling = true)]
            internal extern static unsafe void ClipPlanex(OrkEngine.Rendering.Graphics.ES11.All plane, int* equation);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClipPlanexIMG", ExactSpelling = true)]
            internal extern static unsafe void ClipPlanexIMG(OrkEngine.Rendering.Graphics.ES11.All p, int* eqn);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glClipPlanexOES", ExactSpelling = true)]
            internal extern static unsafe void ClipPlanexOES(OrkEngine.Rendering.Graphics.ES11.All plane, int* equation);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glColor4f", ExactSpelling = true)]
            internal extern static void Color4f(Single red, Single green, Single blue, Single alpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glColor4ub", ExactSpelling = true)]
            internal extern static void Color4ub(Byte red, Byte green, Byte blue, Byte alpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glColor4x", ExactSpelling = true)]
            internal extern static void Color4x(int red, int green, int blue, int alpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glColor4xOES", ExactSpelling = true)]
            internal extern static void Color4xOES(int red, int green, int blue, int alpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glColorMask", ExactSpelling = true)]
            internal extern static void ColorMask(bool red, bool green, bool blue, bool alpha);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glColorPointer", ExactSpelling = true)]
            internal extern static void ColorPointer(Int32 size, OrkEngine.Rendering.Graphics.ES11.All type, Int32 stride, IntPtr pointer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glCompressedTexImage2D", ExactSpelling = true)]
            internal extern static void CompressedTexImage2D(OrkEngine.Rendering.Graphics.ES11.All target, Int32 level, OrkEngine.Rendering.Graphics.ES11.All internalformat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr data);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glCompressedTexSubImage2D", ExactSpelling = true)]
            internal extern static void CompressedTexSubImage2D(OrkEngine.Rendering.Graphics.ES11.All target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OrkEngine.Rendering.Graphics.ES11.All format, Int32 imageSize, IntPtr data);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glCopyTexImage2D", ExactSpelling = true)]
            internal extern static void CopyTexImage2D(OrkEngine.Rendering.Graphics.ES11.All target, Int32 level, OrkEngine.Rendering.Graphics.ES11.All internalformat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glCopyTexSubImage2D", ExactSpelling = true)]
            internal extern static void CopyTexSubImage2D(OrkEngine.Rendering.Graphics.ES11.All target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glCullFace", ExactSpelling = true)]
            internal extern static void CullFace(OrkEngine.Rendering.Graphics.ES11.All mode);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glCurrentPaletteMatrixOES", ExactSpelling = true)]
            internal extern static void CurrentPaletteMatrixOES(UInt32 matrixpaletteindex);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDeleteBuffers", ExactSpelling = true)]
            internal extern static unsafe void DeleteBuffers(Int32 n, UInt32* buffers);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDeleteFencesNV", ExactSpelling = true)]
            internal extern static unsafe void DeleteFencesNV(Int32 n, UInt32* fences);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDeleteFramebuffersOES", ExactSpelling = true)]
            internal extern static unsafe void DeleteFramebuffersOES(Int32 n, UInt32* framebuffers);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDeleteRenderbuffersOES", ExactSpelling = true)]
            internal extern static unsafe void DeleteRenderbuffersOES(Int32 n, UInt32* renderbuffers);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDeleteTextures", ExactSpelling = true)]
            internal extern static unsafe void DeleteTextures(Int32 n, UInt32* textures);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDepthFunc", ExactSpelling = true)]
            internal extern static void DepthFunc(OrkEngine.Rendering.Graphics.ES11.All func);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDepthMask", ExactSpelling = true)]
            internal extern static void DepthMask(bool flag);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDepthRangef", ExactSpelling = true)]
            internal extern static void DepthRangef(Single zNear, Single zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDepthRangefOES", ExactSpelling = true)]
            internal extern static void DepthRangefOES(Single zNear, Single zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDepthRangex", ExactSpelling = true)]
            internal extern static void DepthRangex(int zNear, int zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDepthRangexOES", ExactSpelling = true)]
            internal extern static void DepthRangexOES(int zNear, int zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDisable", ExactSpelling = true)]
            internal extern static void Disable(OrkEngine.Rendering.Graphics.ES11.All cap);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDisableClientState", ExactSpelling = true)]
            internal extern static void DisableClientState(OrkEngine.Rendering.Graphics.ES11.All array);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDisableDriverControlQCOM", ExactSpelling = true)]
            internal extern static void DisableDriverControlQCOM(UInt32 driverControl);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawArrays", ExactSpelling = true)]
            internal extern static void DrawArrays(OrkEngine.Rendering.Graphics.ES11.All mode, Int32 first, Int32 count);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawElements", ExactSpelling = true)]
            internal extern static void DrawElements(OrkEngine.Rendering.Graphics.ES11.All mode, Int32 count, OrkEngine.Rendering.Graphics.ES11.All type, IntPtr indices);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawTexfOES", ExactSpelling = true)]
            internal extern static void DrawTexfOES(Single x, Single y, Single z, Single width, Single height);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawTexfvOES", ExactSpelling = true)]
            internal extern static unsafe void DrawTexfvOES(Single* coords);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawTexiOES", ExactSpelling = true)]
            internal extern static void DrawTexiOES(Int32 x, Int32 y, Int32 z, Int32 width, Int32 height);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawTexivOES", ExactSpelling = true)]
            internal extern static unsafe void DrawTexivOES(Int32* coords);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawTexsOES", ExactSpelling = true)]
            internal extern static void DrawTexsOES(Int16 x, Int16 y, Int16 z, Int16 width, Int16 height);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawTexsvOES", ExactSpelling = true)]
            internal extern static unsafe void DrawTexsvOES(Int16* coords);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawTexxOES", ExactSpelling = true)]
            internal extern static void DrawTexxOES(int x, int y, int z, int width, int height);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glDrawTexxvOES", ExactSpelling = true)]
            internal extern static unsafe void DrawTexxvOES(int* coords);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glEGLImageTargetRenderbufferStorageOES", ExactSpelling = true)]
            internal extern static void EGLImageTargetRenderbufferStorageOES(OrkEngine.Rendering.Graphics.ES11.All target, IntPtr image);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glEGLImageTargetTexture2DOES", ExactSpelling = true)]
            internal extern static void EGLImageTargetTexture2DOES(OrkEngine.Rendering.Graphics.ES11.All target, IntPtr image);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glEnable", ExactSpelling = true)]
            internal extern static void Enable(OrkEngine.Rendering.Graphics.ES11.All cap);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glEnableClientState", ExactSpelling = true)]
            internal extern static void EnableClientState(OrkEngine.Rendering.Graphics.ES11.All array);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glEnableDriverControlQCOM", ExactSpelling = true)]
            internal extern static void EnableDriverControlQCOM(UInt32 driverControl);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFinish", ExactSpelling = true)]
            internal extern static void Finish();
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFinishFenceNV", ExactSpelling = true)]
            internal extern static void FinishFenceNV(UInt32 fence);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFlush", ExactSpelling = true)]
            internal extern static void Flush();
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFogf", ExactSpelling = true)]
            internal extern static void Fogf(OrkEngine.Rendering.Graphics.ES11.All pname, Single param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFogfv", ExactSpelling = true)]
            internal extern static unsafe void Fogfv(OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFogx", ExactSpelling = true)]
            internal extern static void Fogx(OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFogxOES", ExactSpelling = true)]
            internal extern static void FogxOES(OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFogxv", ExactSpelling = true)]
            internal extern static unsafe void Fogxv(OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFogxvOES", ExactSpelling = true)]
            internal extern static unsafe void FogxvOES(OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFramebufferRenderbufferOES", ExactSpelling = true)]
            internal extern static void FramebufferRenderbufferOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All attachment, OrkEngine.Rendering.Graphics.ES11.All renderbuffertarget, UInt32 renderbuffer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFramebufferTexture2DOES", ExactSpelling = true)]
            internal extern static void FramebufferTexture2DOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All attachment, OrkEngine.Rendering.Graphics.ES11.All textarget, UInt32 texture, Int32 level);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFrontFace", ExactSpelling = true)]
            internal extern static void FrontFace(OrkEngine.Rendering.Graphics.ES11.All mode);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFrustumf", ExactSpelling = true)]
            internal extern static void Frustumf(Single left, Single right, Single bottom, Single top, Single zNear, Single zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFrustumfOES", ExactSpelling = true)]
            internal extern static void FrustumfOES(Single left, Single right, Single bottom, Single top, Single zNear, Single zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFrustumx", ExactSpelling = true)]
            internal extern static void Frustumx(int left, int right, int bottom, int top, int zNear, int zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glFrustumxOES", ExactSpelling = true)]
            internal extern static void FrustumxOES(int left, int right, int bottom, int top, int zNear, int zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGenBuffers", ExactSpelling = true)]
            internal extern static unsafe void GenBuffers(Int32 n, UInt32* buffers);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGenerateMipmapOES", ExactSpelling = true)]
            internal extern static void GenerateMipmapOES(OrkEngine.Rendering.Graphics.ES11.All target);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGenFencesNV", ExactSpelling = true)]
            internal extern static unsafe void GenFencesNV(Int32 n, UInt32* fences);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGenFramebuffersOES", ExactSpelling = true)]
            internal extern static unsafe void GenFramebuffersOES(Int32 n, UInt32* framebuffers);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGenRenderbuffersOES", ExactSpelling = true)]
            internal extern static unsafe void GenRenderbuffersOES(Int32 n, UInt32* renderbuffers);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGenTextures", ExactSpelling = true)]
            internal extern static unsafe void GenTextures(Int32 n, UInt32* textures);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetBooleanv", ExactSpelling = true)]
            internal extern static unsafe void GetBooleanv(OrkEngine.Rendering.Graphics.ES11.All pname, bool* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetBufferParameteriv", ExactSpelling = true)]
            internal extern static unsafe void GetBufferParameteriv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetBufferPointervOES", ExactSpelling = true)]
            internal extern static void GetBufferPointervOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, IntPtr @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetClipPlanef", ExactSpelling = true)]
            internal extern static unsafe void GetClipPlanef(OrkEngine.Rendering.Graphics.ES11.All pname, Single* eqn);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetClipPlanefOES", ExactSpelling = true)]
            internal extern static unsafe void GetClipPlanefOES(OrkEngine.Rendering.Graphics.ES11.All pname, Single* eqn);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetClipPlanex", ExactSpelling = true)]
            internal extern static unsafe void GetClipPlanex(OrkEngine.Rendering.Graphics.ES11.All pname, int* eqn);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetClipPlanexOES", ExactSpelling = true)]
            internal extern static unsafe void GetClipPlanexOES(OrkEngine.Rendering.Graphics.ES11.All pname, int* eqn);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetDriverControlsQCOM", ExactSpelling = true)]
            internal extern static unsafe void GetDriverControlsQCOM(Int32* num, Int32 size, UInt32* driverControls);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetDriverControlStringQCOM", ExactSpelling = true)]
            internal extern static unsafe void GetDriverControlStringQCOM(UInt32 driverControl, Int32 bufSize, Int32* length, String driverControlString);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetError", ExactSpelling = true)]
            internal extern static OrkEngine.Rendering.Graphics.ES11.All GetError();
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetFenceivNV", ExactSpelling = true)]
            internal extern static unsafe void GetFenceivNV(UInt32 fence, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetFixedv", ExactSpelling = true)]
            internal extern static unsafe void GetFixedv(OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetFixedvOES", ExactSpelling = true)]
            internal extern static unsafe void GetFixedvOES(OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetFloatv", ExactSpelling = true)]
            internal extern static unsafe void GetFloatv(OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetFramebufferAttachmentParameterivOES", ExactSpelling = true)]
            internal extern static unsafe void GetFramebufferAttachmentParameterivOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All attachment, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetIntegerv", ExactSpelling = true)]
            internal extern static unsafe void GetIntegerv(OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetLightfv", ExactSpelling = true)]
            internal extern static unsafe void GetLightfv(OrkEngine.Rendering.Graphics.ES11.All light, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetLightxv", ExactSpelling = true)]
            internal extern static unsafe void GetLightxv(OrkEngine.Rendering.Graphics.ES11.All light, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetLightxvOES", ExactSpelling = true)]
            internal extern static unsafe void GetLightxvOES(OrkEngine.Rendering.Graphics.ES11.All light, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetMaterialfv", ExactSpelling = true)]
            internal extern static unsafe void GetMaterialfv(OrkEngine.Rendering.Graphics.ES11.All face, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetMaterialxv", ExactSpelling = true)]
            internal extern static unsafe void GetMaterialxv(OrkEngine.Rendering.Graphics.ES11.All face, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetMaterialxvOES", ExactSpelling = true)]
            internal extern static unsafe void GetMaterialxvOES(OrkEngine.Rendering.Graphics.ES11.All face, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetPointerv", ExactSpelling = true)]
            internal extern static void GetPointerv(OrkEngine.Rendering.Graphics.ES11.All pname, IntPtr @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetRenderbufferParameterivOES", ExactSpelling = true)]
            internal extern static unsafe void GetRenderbufferParameterivOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetString", ExactSpelling = true)]
            internal extern static unsafe System.IntPtr GetString(OrkEngine.Rendering.Graphics.ES11.All name);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexEnvfv", ExactSpelling = true)]
            internal extern static unsafe void GetTexEnvfv(OrkEngine.Rendering.Graphics.ES11.All env, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexEnviv", ExactSpelling = true)]
            internal extern static unsafe void GetTexEnviv(OrkEngine.Rendering.Graphics.ES11.All env, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexEnvxv", ExactSpelling = true)]
            internal extern static unsafe void GetTexEnvxv(OrkEngine.Rendering.Graphics.ES11.All env, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexEnvxvOES", ExactSpelling = true)]
            internal extern static unsafe void GetTexEnvxvOES(OrkEngine.Rendering.Graphics.ES11.All env, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexGenfvOES", ExactSpelling = true)]
            internal extern static unsafe void GetTexGenfvOES(OrkEngine.Rendering.Graphics.ES11.All coord, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexGenivOES", ExactSpelling = true)]
            internal extern static unsafe void GetTexGenivOES(OrkEngine.Rendering.Graphics.ES11.All coord, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexGenxvOES", ExactSpelling = true)]
            internal extern static unsafe void GetTexGenxvOES(OrkEngine.Rendering.Graphics.ES11.All coord, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexParameterfv", ExactSpelling = true)]
            internal extern static unsafe void GetTexParameterfv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexParameteriv", ExactSpelling = true)]
            internal extern static unsafe void GetTexParameteriv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexParameterxv", ExactSpelling = true)]
            internal extern static unsafe void GetTexParameterxv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glGetTexParameterxvOES", ExactSpelling = true)]
            internal extern static unsafe void GetTexParameterxvOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glHint", ExactSpelling = true)]
            internal extern static void Hint(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All mode);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glIsBuffer", ExactSpelling = true)]
            internal extern static bool IsBuffer(UInt32 buffer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glIsEnabled", ExactSpelling = true)]
            internal extern static bool IsEnabled(OrkEngine.Rendering.Graphics.ES11.All cap);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glIsFenceNV", ExactSpelling = true)]
            internal extern static bool IsFenceNV(UInt32 fence);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glIsFramebufferOES", ExactSpelling = true)]
            internal extern static bool IsFramebufferOES(UInt32 framebuffer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glIsRenderbufferOES", ExactSpelling = true)]
            internal extern static bool IsRenderbufferOES(UInt32 renderbuffer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glIsTexture", ExactSpelling = true)]
            internal extern static bool IsTexture(UInt32 texture);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightf", ExactSpelling = true)]
            internal extern static void Lightf(OrkEngine.Rendering.Graphics.ES11.All light, OrkEngine.Rendering.Graphics.ES11.All pname, Single param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightfv", ExactSpelling = true)]
            internal extern static unsafe void Lightfv(OrkEngine.Rendering.Graphics.ES11.All light, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightModelf", ExactSpelling = true)]
            internal extern static void LightModelf(OrkEngine.Rendering.Graphics.ES11.All pname, Single param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightModelfv", ExactSpelling = true)]
            internal extern static unsafe void LightModelfv(OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightModelx", ExactSpelling = true)]
            internal extern static void LightModelx(OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightModelxOES", ExactSpelling = true)]
            internal extern static void LightModelxOES(OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightModelxv", ExactSpelling = true)]
            internal extern static unsafe void LightModelxv(OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightModelxvOES", ExactSpelling = true)]
            internal extern static unsafe void LightModelxvOES(OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightx", ExactSpelling = true)]
            internal extern static void Lightx(OrkEngine.Rendering.Graphics.ES11.All light, OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightxOES", ExactSpelling = true)]
            internal extern static void LightxOES(OrkEngine.Rendering.Graphics.ES11.All light, OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightxv", ExactSpelling = true)]
            internal extern static unsafe void Lightxv(OrkEngine.Rendering.Graphics.ES11.All light, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLightxvOES", ExactSpelling = true)]
            internal extern static unsafe void LightxvOES(OrkEngine.Rendering.Graphics.ES11.All light, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLineWidth", ExactSpelling = true)]
            internal extern static void LineWidth(Single width);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLineWidthx", ExactSpelling = true)]
            internal extern static void LineWidthx(int width);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLineWidthxOES", ExactSpelling = true)]
            internal extern static void LineWidthxOES(int width);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLoadIdentity", ExactSpelling = true)]
            internal extern static void LoadIdentity();
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLoadMatrixf", ExactSpelling = true)]
            internal extern static unsafe void LoadMatrixf(Single* m);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLoadMatrixx", ExactSpelling = true)]
            internal extern static unsafe void LoadMatrixx(int* m);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLoadMatrixxOES", ExactSpelling = true)]
            internal extern static unsafe void LoadMatrixxOES(int* m);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLoadPaletteFromModelViewMatrixOES", ExactSpelling = true)]
            internal extern static void LoadPaletteFromModelViewMatrixOES();
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glLogicOp", ExactSpelling = true)]
            internal extern static void LogicOp(OrkEngine.Rendering.Graphics.ES11.All opcode);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMapBufferOES", ExactSpelling = true)]
            internal extern static unsafe System.IntPtr MapBufferOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All access);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMaterialf", ExactSpelling = true)]
            internal extern static void Materialf(OrkEngine.Rendering.Graphics.ES11.All face, OrkEngine.Rendering.Graphics.ES11.All pname, Single param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMaterialfv", ExactSpelling = true)]
            internal extern static unsafe void Materialfv(OrkEngine.Rendering.Graphics.ES11.All face, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMaterialx", ExactSpelling = true)]
            internal extern static void Materialx(OrkEngine.Rendering.Graphics.ES11.All face, OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMaterialxOES", ExactSpelling = true)]
            internal extern static void MaterialxOES(OrkEngine.Rendering.Graphics.ES11.All face, OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMaterialxv", ExactSpelling = true)]
            internal extern static unsafe void Materialxv(OrkEngine.Rendering.Graphics.ES11.All face, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMaterialxvOES", ExactSpelling = true)]
            internal extern static unsafe void MaterialxvOES(OrkEngine.Rendering.Graphics.ES11.All face, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMatrixIndexPointerOES", ExactSpelling = true)]
            internal extern static void MatrixIndexPointerOES(Int32 size, OrkEngine.Rendering.Graphics.ES11.All type, Int32 stride, IntPtr pointer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMatrixMode", ExactSpelling = true)]
            internal extern static void MatrixMode(OrkEngine.Rendering.Graphics.ES11.All mode);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMultiTexCoord4f", ExactSpelling = true)]
            internal extern static void MultiTexCoord4f(OrkEngine.Rendering.Graphics.ES11.All target, Single s, Single t, Single r, Single q);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMultiTexCoord4x", ExactSpelling = true)]
            internal extern static void MultiTexCoord4x(OrkEngine.Rendering.Graphics.ES11.All target, int s, int t, int r, int q);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMultiTexCoord4xOES", ExactSpelling = true)]
            internal extern static void MultiTexCoord4xOES(OrkEngine.Rendering.Graphics.ES11.All target, int s, int t, int r, int q);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMultMatrixf", ExactSpelling = true)]
            internal extern static unsafe void MultMatrixf(Single* m);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMultMatrixx", ExactSpelling = true)]
            internal extern static unsafe void MultMatrixx(int* m);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glMultMatrixxOES", ExactSpelling = true)]
            internal extern static unsafe void MultMatrixxOES(int* m);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glNormal3f", ExactSpelling = true)]
            internal extern static void Normal3f(Single nx, Single ny, Single nz);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glNormal3x", ExactSpelling = true)]
            internal extern static void Normal3x(int nx, int ny, int nz);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glNormal3xOES", ExactSpelling = true)]
            internal extern static void Normal3xOES(int nx, int ny, int nz);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glNormalPointer", ExactSpelling = true)]
            internal extern static void NormalPointer(OrkEngine.Rendering.Graphics.ES11.All type, Int32 stride, IntPtr pointer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glOrthof", ExactSpelling = true)]
            internal extern static void Orthof(Single left, Single right, Single bottom, Single top, Single zNear, Single zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glOrthofOES", ExactSpelling = true)]
            internal extern static void OrthofOES(Single left, Single right, Single bottom, Single top, Single zNear, Single zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glOrthox", ExactSpelling = true)]
            internal extern static void Orthox(int left, int right, int bottom, int top, int zNear, int zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glOrthoxOES", ExactSpelling = true)]
            internal extern static void OrthoxOES(int left, int right, int bottom, int top, int zNear, int zFar);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPixelStorei", ExactSpelling = true)]
            internal extern static void PixelStorei(OrkEngine.Rendering.Graphics.ES11.All pname, Int32 param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointParameterf", ExactSpelling = true)]
            internal extern static void PointParameterf(OrkEngine.Rendering.Graphics.ES11.All pname, Single param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointParameterfv", ExactSpelling = true)]
            internal extern static unsafe void PointParameterfv(OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointParameterx", ExactSpelling = true)]
            internal extern static void PointParameterx(OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointParameterxOES", ExactSpelling = true)]
            internal extern static void PointParameterxOES(OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointParameterxv", ExactSpelling = true)]
            internal extern static unsafe void PointParameterxv(OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointParameterxvOES", ExactSpelling = true)]
            internal extern static unsafe void PointParameterxvOES(OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointSize", ExactSpelling = true)]
            internal extern static void PointSize(Single size);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointSizePointerOES", ExactSpelling = true)]
            internal extern static void PointSizePointerOES(OrkEngine.Rendering.Graphics.ES11.All type, Int32 stride, IntPtr pointer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointSizex", ExactSpelling = true)]
            internal extern static void PointSizex(int size);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPointSizexOES", ExactSpelling = true)]
            internal extern static void PointSizexOES(int size);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPolygonOffset", ExactSpelling = true)]
            internal extern static void PolygonOffset(Single factor, Single units);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPolygonOffsetx", ExactSpelling = true)]
            internal extern static void PolygonOffsetx(int factor, int units);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPolygonOffsetxOES", ExactSpelling = true)]
            internal extern static void PolygonOffsetxOES(int factor, int units);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPopMatrix", ExactSpelling = true)]
            internal extern static void PopMatrix();
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glPushMatrix", ExactSpelling = true)]
            internal extern static void PushMatrix();
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glQueryMatrixxOES", ExactSpelling = true)]
            internal extern static unsafe Int32 QueryMatrixxOES(int* mantissa, Int32* exponent);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glReadPixels", ExactSpelling = true)]
            internal extern static void ReadPixels(Int32 x, Int32 y, Int32 width, Int32 height, OrkEngine.Rendering.Graphics.ES11.All format, OrkEngine.Rendering.Graphics.ES11.All type, IntPtr pixels);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glRenderbufferStorageOES", ExactSpelling = true)]
            internal extern static void RenderbufferStorageOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All internalformat, Int32 width, Int32 height);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glRotatef", ExactSpelling = true)]
            internal extern static void Rotatef(Single angle, Single x, Single y, Single z);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glRotatex", ExactSpelling = true)]
            internal extern static void Rotatex(int angle, int x, int y, int z);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glRotatexOES", ExactSpelling = true)]
            internal extern static void RotatexOES(int angle, int x, int y, int z);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glSampleCoverage", ExactSpelling = true)]
            internal extern static void SampleCoverage(Single value, bool invert);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glSampleCoveragex", ExactSpelling = true)]
            internal extern static void SampleCoveragex(int value, bool invert);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glSampleCoveragexOES", ExactSpelling = true)]
            internal extern static void SampleCoveragexOES(int value, bool invert);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glScalef", ExactSpelling = true)]
            internal extern static void Scalef(Single x, Single y, Single z);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glScalex", ExactSpelling = true)]
            internal extern static void Scalex(int x, int y, int z);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glScalexOES", ExactSpelling = true)]
            internal extern static void ScalexOES(int x, int y, int z);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glScissor", ExactSpelling = true)]
            internal extern static void Scissor(Int32 x, Int32 y, Int32 width, Int32 height);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glSetFenceNV", ExactSpelling = true)]
            internal extern static void SetFenceNV(UInt32 fence, OrkEngine.Rendering.Graphics.ES11.All condition);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glShadeModel", ExactSpelling = true)]
            internal extern static void ShadeModel(OrkEngine.Rendering.Graphics.ES11.All mode);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glStencilFunc", ExactSpelling = true)]
            internal extern static void StencilFunc(OrkEngine.Rendering.Graphics.ES11.All func, Int32 @ref, UInt32 mask);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glStencilMask", ExactSpelling = true)]
            internal extern static void StencilMask(UInt32 mask);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glStencilOp", ExactSpelling = true)]
            internal extern static void StencilOp(OrkEngine.Rendering.Graphics.ES11.All fail, OrkEngine.Rendering.Graphics.ES11.All zfail, OrkEngine.Rendering.Graphics.ES11.All zpass);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTestFenceNV", ExactSpelling = true)]
            internal extern static bool TestFenceNV(UInt32 fence);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexCoordPointer", ExactSpelling = true)]
            internal extern static void TexCoordPointer(Int32 size, OrkEngine.Rendering.Graphics.ES11.All type, Int32 stride, IntPtr pointer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexEnvf", ExactSpelling = true)]
            internal extern static void TexEnvf(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Single param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexEnvfv", ExactSpelling = true)]
            internal extern static unsafe void TexEnvfv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexEnvi", ExactSpelling = true)]
            internal extern static void TexEnvi(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Int32 param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexEnviv", ExactSpelling = true)]
            internal extern static unsafe void TexEnviv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexEnvx", ExactSpelling = true)]
            internal extern static void TexEnvx(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexEnvxOES", ExactSpelling = true)]
            internal extern static void TexEnvxOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexEnvxv", ExactSpelling = true)]
            internal extern static unsafe void TexEnvxv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexEnvxvOES", ExactSpelling = true)]
            internal extern static unsafe void TexEnvxvOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexGenfOES", ExactSpelling = true)]
            internal extern static void TexGenfOES(OrkEngine.Rendering.Graphics.ES11.All coord, OrkEngine.Rendering.Graphics.ES11.All pname, Single param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexGenfvOES", ExactSpelling = true)]
            internal extern static unsafe void TexGenfvOES(OrkEngine.Rendering.Graphics.ES11.All coord, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexGeniOES", ExactSpelling = true)]
            internal extern static void TexGeniOES(OrkEngine.Rendering.Graphics.ES11.All coord, OrkEngine.Rendering.Graphics.ES11.All pname, Int32 param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexGenivOES", ExactSpelling = true)]
            internal extern static unsafe void TexGenivOES(OrkEngine.Rendering.Graphics.ES11.All coord, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexGenxOES", ExactSpelling = true)]
            internal extern static void TexGenxOES(OrkEngine.Rendering.Graphics.ES11.All coord, OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexGenxvOES", ExactSpelling = true)]
            internal extern static unsafe void TexGenxvOES(OrkEngine.Rendering.Graphics.ES11.All coord, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexImage2D", ExactSpelling = true)]
            internal extern static void TexImage2D(OrkEngine.Rendering.Graphics.ES11.All target, Int32 level, Int32 internalformat, Int32 width, Int32 height, Int32 border, OrkEngine.Rendering.Graphics.ES11.All format, OrkEngine.Rendering.Graphics.ES11.All type, IntPtr pixels);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexParameterf", ExactSpelling = true)]
            internal extern static void TexParameterf(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Single param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexParameterfv", ExactSpelling = true)]
            internal extern static unsafe void TexParameterfv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Single* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexParameteri", ExactSpelling = true)]
            internal extern static void TexParameteri(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Int32 param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexParameteriv", ExactSpelling = true)]
            internal extern static unsafe void TexParameteriv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, Int32* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexParameterx", ExactSpelling = true)]
            internal extern static void TexParameterx(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexParameterxOES", ExactSpelling = true)]
            internal extern static void TexParameterxOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int param);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexParameterxv", ExactSpelling = true)]
            internal extern static unsafe void TexParameterxv(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexParameterxvOES", ExactSpelling = true)]
            internal extern static unsafe void TexParameterxvOES(OrkEngine.Rendering.Graphics.ES11.All target, OrkEngine.Rendering.Graphics.ES11.All pname, int* @params);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTexSubImage2D", ExactSpelling = true)]
            internal extern static void TexSubImage2D(OrkEngine.Rendering.Graphics.ES11.All target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OrkEngine.Rendering.Graphics.ES11.All format, OrkEngine.Rendering.Graphics.ES11.All type, IntPtr pixels);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTranslatef", ExactSpelling = true)]
            internal extern static void Translatef(Single x, Single y, Single z);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTranslatex", ExactSpelling = true)]
            internal extern static void Translatex(int x, int y, int z);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glTranslatexOES", ExactSpelling = true)]
            internal extern static void TranslatexOES(int x, int y, int z);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glUnmapBufferOES", ExactSpelling = true)]
            internal extern static bool UnmapBufferOES(OrkEngine.Rendering.Graphics.ES11.All target);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glVertexPointer", ExactSpelling = true)]
            internal extern static void VertexPointer(Int32 size, OrkEngine.Rendering.Graphics.ES11.All type, Int32 stride, IntPtr pointer);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glViewport", ExactSpelling = true)]
            internal extern static void Viewport(Int32 x, Int32 y, Int32 width, Int32 height);
            [System.Security.SuppressUnmanagedCodeSecurity()]
            [System.Runtime.InteropServices.DllImport(GL.Library, EntryPoint = "glWeightPointerOES", ExactSpelling = true)]
            internal extern static void WeightPointerOES(Int32 size, OrkEngine.Rendering.Graphics.ES11.All type, Int32 stride, IntPtr pointer);
        }
    }
}
