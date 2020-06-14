using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using OrkEngine.Graphics.Common;

namespace OrkEngine.Graphics
{
    public class Window : GameWindow
    {

        List<GameObject> Objects = new List<GameObject>();

        private Shader _shader;

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
            GL.ClearColor(0f, 0f, 0.05f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            _shader = new Shader(@"Shaders\shader.vert", @"Shaders\shader.frag");
            _shader.Use();

            _shader.SetInt("texture0", 0);

            var vertexLocation = _shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            var texCoordLocation = _shader.GetAttribLocation("aTexCoord");
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

            _shader.SetMatrix4("view", camera.GetViewMatrix());
                _shader.SetMatrix4("projection", camera.GetProjectionMatrix());

            foreach (GameObject obj in Objects)
            {
                Model m = new Model();

                if (obj.modelIndex > obj.models.Count - 1)
                {
                    m = Model.Cube;
                    Console.WriteLine("[!] Model Index {0} was out of bounds. GameObject: {1}", obj.modelIndex, obj.name);
                }
                else
                    m = obj.models[obj.modelIndex];

                GL.BindVertexArray(m.vertexArrayObject);

                m.texture.Use();
                _shader.Use();

                Matrix4 model = Matrix4.Identity * Matrix4.CreateRotationX(obj.rotation.X) * Matrix4.CreateRotationY(obj.rotation.Y) * Matrix4.CreateRotationZ(obj.rotation.Z) * Matrix4.CreateTranslation(obj.position) * Matrix4.CreateScale(obj.scale);
                _shader.SetMatrix4("model", model);

                GL.DrawElements((PrimitiveType)m.renderMode, m.indices.Length, DrawElementsType.UnsignedInt, 0);
                GL.BindVertexArray(0);
            }

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        public void AddToRenderQueue(GameObject obj)
        {
            foreach (Model m in obj.models) {
                m.vertexBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ArrayBuffer, m.vertexBufferObject);
                GL.BufferData(BufferTarget.ArrayBuffer, m.vertices.Length * sizeof(float), m.vertices, BufferUsageHint.StaticDraw);

                m.elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, m.elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, m.indices.Length * sizeof(uint), m.indices, BufferUsageHint.StaticDraw);

                m.vertexArrayObject = GL.GenVertexArray();
                GL.BindVertexArray(m.vertexArrayObject);

                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
                GL.EnableVertexAttribArray(0);

                GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
                GL.EnableVertexAttribArray(1);

                GL.BindBuffer(BufferTarget.ArrayBuffer, m.vertexBufferObject);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, m.elementBufferObject);
            }

            Objects.Add(obj);
            Console.WriteLine("Added: " + obj.name);
        }

        public void RemoveFromRenderQueue(Model rend)
        {
            /*List<Model> delete = Objects.FindAll(r => r.randID == rend.randID);
            foreach (Model del in delete)
            {
                GL.DeleteBuffer(del.vertexBufferObject);
                GL.DeleteVertexArray(del.vertexArrayObject);
                GL.DeleteTexture(del.texture.Handle);
                Objects.Remove(del);
            }*/
        }

        public void ClearRenderQueue()
        {
            foreach (GameObject obj in Objects)
            {
                foreach (Model m in obj.models) {
                    GL.DeleteBuffer(m.vertexBufferObject);
                    GL.DeleteVertexArray(m.vertexArrayObject);
                    GL.DeleteTexture(m.texture.Handle);
                }
            }
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

            ClearRenderQueue();

            GL.DeleteProgram(_shader.Handle);

            base.OnUnload(e);
        }
    }
}