using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using OrkEngine.Graphics.Common;

namespace OrkEngine.Graphics
{
    public class Window : GameWindow
    {

        public List<Renderable> Renderables = new List<Renderable>();

        private Shader shader;

        public Camera camera;

        private bool _firstMove = true;

        private Vector2 _lastPos;

        private double _time;

        Func<object> Start;
        Func<object> Update;

        public double deltaTime = 0;

        public Window(int width, int height, string title, Func<object> start, Func<object> update)
            : base(width, height, GraphicsMode.Default, title)
        {
            Start = start;
            Update = update;
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            shader = new Shader(@"C:\Users\User\Documents\GitHub\OrkEngine\OrkCore\Graphics\Shaders\shader.vert", @"C:\Users\User\Documents\GitHub\OrkEngine\OrkCore\Graphics\Shaders\shader.frag");
            shader.Use();
            shader.SetInt("texture0", 0);

            var vertexLocation = shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            var texCoordLocation = shader.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

            camera = new Camera(Vector3.UnitZ * 3, Width / (float)Height);

            CursorVisible = false;

            Start();

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _time += 4.0 * e.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (Renderable rend in Renderables) {
                GL.BindVertexArray(rend.vertexArrayObject);

                rend.texture.Use();
                shader.Use();

                var model = Matrix4.Identity * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(_time * 4)) * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(_time * 2));
                shader.SetMatrix4("model", model);
                shader.SetMatrix4("view", camera.GetViewMatrix());
                shader.SetMatrix4("projection", camera.GetProjectionMatrix());

                GL.DrawElements(PrimitiveType.Triangles, rend.indices.Length, DrawElementsType.UnsignedInt, 0);
            }

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        public bool KeyDown(Key key)
        {
            var input = Keyboard.GetState();

            if (input.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        public void AddToRenderQueue(Renderable rend)
        {
            rend.vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, rend.vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, rend.vertices.Length * sizeof(float), rend.vertices, BufferUsageHint.StaticDraw);

            rend.elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, rend.elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, rend.indices.Length * sizeof(uint), rend.indices, BufferUsageHint.StaticDraw);

            rend.vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(rend.vertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, rend.vertexArrayObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, rend.elementBufferObject);

            Renderables.Add(rend);
        }

        public void RemoveFromRenderQueue(Renderable rend)
        {
            
        }

        public void ClearRenderQueue()
        {
            foreach (Renderable rend in Renderables)
            {
                GL.DeleteBuffer(rend.vertexBufferObject);
                GL.DeleteVertexArray(rend.vertexArrayObject);
                GL.DeleteTexture(rend.texture.Handle);
            }
            Renderables.Clear();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var input = Keyboard.GetState();

            deltaTime = e.Time;

            Update();

            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            camera.AspectRatio = Width / (float)Height;
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            foreach (Renderable rend in Renderables)
            {
                GL.DeleteBuffer(rend.vertexBufferObject);
                GL.DeleteVertexArray(rend.vertexArrayObject);
                GL.DeleteTexture(rend.texture.Handle);
            }

            GL.DeleteProgram(shader.Handle);

            base.OnUnload(e);
        }
    }
}