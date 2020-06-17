using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly Vector3 _lightPos = new Vector3(1.2f, 1.0f, 2.0f);

        private int _vertexBufferObject;

        private int _vaoModel;

        private int _vaoLamp;

        private Shader _lampShader;

        private Shader _lightingShader;

        private Texture _diffuseMap;

        private Texture _specularMap;

        public Camera camera;

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
            GL.ClearColor(0.05f, 0.05f, 0.07f, 1.0f);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            //GL.Enable(EnableCap.CullFace);

            _lightingShader = new Shader("Graphics/Shaders/shader.vert", "Graphics/Shaders/lighting.frag");
            _lampShader = new Shader("Graphics/Shaders/shader.vert", "Graphics/Shaders/shader.frag");
            _diffuseMap = new Texture("Textures/Diffuse_2K.png");
            _specularMap = new Texture("Textures/Bump_2K.png");

            camera = new Camera(Vector3.UnitZ * 3, Width / (float)Height);

            CursorVisible = false;

            Start();

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _lightingShader.SetVector3("light.direction", new Vector3(0.5f, -0.3f, -0.5f));
            _lightingShader.SetVector3("light.ambient", new Vector3(0.2f));
            _lightingShader.SetVector3("light.diffuse", new Vector3(0.5f));
            _lightingShader.SetVector3("light.specular", new Vector3(1.0f));

            foreach (GameObject obj in Objects)
            {
                Model m = new Model();

                if (obj.modelIndex > obj.models.Count - 1)
                {
                    m = obj.models[0];
                    Console.WriteLine("[!] Model Index {0} was out of bounds. GameObject: {1}", obj.modelIndex, obj.name);
                }
                else
                    m = obj.ActiveModel;

                GL.BindVertexArray(m.vertexArrayObject);

                m.material.diffuseMap.Use();
                m.material.specularMap.Use(TextureUnit.Texture1);
                _lightingShader.Use();

                _lightingShader.SetMatrix4("view", camera.GetViewMatrix());
                _lightingShader.SetMatrix4("projection", camera.GetProjectionMatrix());

                _lightingShader.SetVector3("viewPos", camera.Position);

                //material settings -> will be set by the model later
                _lightingShader.SetInt("material.diffuse", 0);
                _lightingShader.SetInt("material.specular", 1);
                _lightingShader.SetVector3("material.specular", m.material.specular);
                _lightingShader.SetFloat("material.shininess", m.material.shininess);

                Matrix4 model = Matrix4.Identity * Matrix4.CreateRotationX((float)Math.PI / 180 * obj.rotation.X) * Matrix4.CreateRotationY((float)Math.PI / 180 * obj.rotation.Y) * Matrix4.CreateRotationZ((float)Math.PI / 180 * obj.rotation.Z) * Matrix4.CreateTranslation(obj.position) * Matrix4.CreateScale(obj.scale);
                _lightingShader.SetMatrix4("model", model);

                GL.DrawArrays((PrimitiveType)m.renderMode, 0, m.vertices.Length / 8);
                GL.BindVertexArray(0);
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

        public void AddToRenderQueue(GameObject obj)
        {
            foreach (Model m in obj.models)
            {
                m.vertexBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ArrayBuffer, m.vertexBufferObject);
                GL.BufferData(BufferTarget.ArrayBuffer, m.vertices.Length * sizeof(float), m.vertices, BufferUsageHint.StaticDraw);

                m.vertexArrayObject = GL.GenVertexArray();
                GL.BindVertexArray(m.vertexArrayObject);

                GL.BindBuffer(BufferTarget.ArrayBuffer, m.vertexBufferObject);

                var positionLocation = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);
                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

                var normalLocation = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation);
                GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

                var texCoordLocation = _lightingShader.GetAttribLocation("aTexCoords");
                GL.EnableVertexAttribArray(texCoordLocation);
                GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));
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
                foreach (Model m in obj.models)
                {
                    GL.DeleteBuffer(m.vertexBufferObject);
                    GL.DeleteVertexArray(m.vertexArrayObject);
                    GL.DeleteTexture(m.material.diffuseMap.Handle);
                }
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_vaoModel);
            GL.DeleteVertexArray(_vaoLamp);

            GL.DeleteProgram(_lampShader.Handle);
            GL.DeleteProgram(_lightingShader.Handle);

            base.OnUnload(e);
        }
    }
}