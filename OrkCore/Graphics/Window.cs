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

        private readonly Vector3 m_lightPos = new Vector3(1.2f, 1.0f, 2.0f);

        private int m_vertexBufferObject;

        private int m_vaoModel;

        private int m_vaoLamp;

        private Shader m_lampShader;

        private Shader m_lightingShader;

        private Texture m_diffuseMap;

        private Texture m_specularMap;

        public GameObject Camera;

        Func<object> Start;
        Func<object> Update;

        public double DeltaTime = 0;

        public Window(int width, int height, string title, Func<object> start, Func<object> update)
            : base(width, height, GraphicsMode.Default, title)
        {
            Start = start;
            Update = update;
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(139 / 255f, 182 / 255f, 201 / 255f, 1.0f);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            //GL.Enable(EnableCap.CullFace);

            m_lightingShader = new Shader("Graphics/Shaders/shader.vert", "Graphics/Shaders/lighting.frag");
            m_lampShader = new Shader("Graphics/Shaders/shader.vert", "Graphics/Shaders/shader.frag");
            m_diffuseMap = new Texture("Textures/Diffuse_2K.png");
            m_specularMap = new Texture("Textures/Bump_2K.png");

            Camera = GameObject.Camera(Width / (float)Height);

            CursorVisible = false;

            Start();

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            m_lightingShader.SetVector3("light.direction", new Vector3(0.5f, -0.3f, -0.5f));
            m_lightingShader.SetVector3("light.ambient", new Vector3(0.2f));
            m_lightingShader.SetVector3("light.diffuse", new Vector3(0.5f));
            m_lightingShader.SetVector3("light.specular", new Vector3(0.0f));

            foreach (GameObject obj in Objects)
            {
                Model mod = new Model();

                if (obj.ModelIndex > obj.Models.Count - 1)
                {
                    mod = obj.Models[0];
                    Console.WriteLine("[!] Model Index {0} was out of bounds. GameObject: {1}", obj.ModelIndex, obj.Name);
                }
                else
                    mod = obj.ActiveModel;

                foreach (Mesh m in mod.meshes)
                {
                    GL.BindVertexArray(m.VertexArrayObject);

                    m.Material.DiffuseMap.Use();
                    m.Material.SpecularMap.Use(TextureUnit.Texture1);
                    m_lightingShader.Use();

                    m_lightingShader.SetMatrix4("view", (Matrix4)Camera.CallAction("viewMatrix", ""));
                    m_lightingShader.SetMatrix4("projection", (Matrix4)Camera.CallAction("projectionMatrix", ""));

                    m_lightingShader.SetVector3("viewPos", Camera.Position);

                    m_lightingShader.SetInt("material.diffuse", 0);
                    m_lightingShader.SetInt("material.specular", 1);
                    m_lightingShader.SetVector3("material.specular", m.Material.Specular);
                    m_lightingShader.SetFloat("material.shininess", m.Material.Shininess);

                    Matrix4 model = Matrix4.Identity;

                    model *= Rotate(obj.Rotation); // obj rotation
                    model *= Translate(obj.Position); // object position
                    model *= Matrix4.CreateScale(obj.Scale); // object scale

                    model *= Rotate(obj.Offset.Rotation); // parent rotation
                    model *= Translate(obj.Offset.Position); // parent position
                    model *= Matrix4.CreateScale(obj.Offset.Scale); // parent scale

                    m_lightingShader.SetMatrix4("model", model);

                    GL.DrawArrays((PrimitiveType)mod.renderMode, 0, m.Vertices.Length / 8);
                    GL.BindVertexArray(0);
                }
            }

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        public Matrix4 Rotate(Vector3 rot)
        {
            return Matrix4.CreateRotationX((float)Math.PI / 180 * (rot.X)) * Matrix4.CreateRotationY((float)Math.PI / 180 * (rot.Y)) * Matrix4.CreateRotationZ((float)Math.PI / 180 * (rot.Z));
        }
        public Matrix4 Translate(Vector3 pos)
        {
            return Matrix4.CreateTranslation(pos);
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

            DeltaTime = e.Time;

            Update();

            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            Camera.ActionData["ASPECT"] = Width / (float)Height;
            base.OnResize(e);
        }

        public void AddToRenderQueue(GameObject obj)
        {
            foreach (Model mod in obj.Models) {
                foreach (Mesh m in mod.meshes)
                {
                    m.VertexBufferObject = GL.GenBuffer();
                    GL.BindBuffer(BufferTarget.ArrayBuffer, m.VertexBufferObject);
                    GL.BufferData(BufferTarget.ArrayBuffer, m.Vertices.Length * sizeof(float), m.Vertices, BufferUsageHint.StaticDraw);

                    m.VertexArrayObject = GL.GenVertexArray();
                    GL.BindVertexArray(m.VertexArrayObject);

                    GL.BindBuffer(BufferTarget.ArrayBuffer, m.VertexBufferObject);

                    var positionLocation = m_lightingShader.GetAttribLocation("aPos");
                    GL.EnableVertexAttribArray(positionLocation);
                    GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

                    var normalLocation = m_lightingShader.GetAttribLocation("aNormal");
                    GL.EnableVertexAttribArray(normalLocation);
                    GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

                    var texCoordLocation = m_lightingShader.GetAttribLocation("aTexCoords");
                    GL.EnableVertexAttribArray(texCoordLocation);
                    GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));
                }
            }

            Objects.Add(obj);
            Console.WriteLine("Added: " + obj.Name);
        }

        public void RemoveFromRenderQueue(Mesh rend)
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
                foreach (Model mod in obj.Models)
                    foreach (Mesh m in mod.meshes)
                    {
                        GL.DeleteBuffer(m.VertexBufferObject);
                        GL.DeleteVertexArray(m.VertexArrayObject);
                        GL.DeleteTexture(m.Material.DiffuseMap.Handle);
                    }
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            GL.DeleteBuffer(m_vertexBufferObject);
            GL.DeleteVertexArray(m_vaoModel);
            GL.DeleteVertexArray(m_vaoLamp);

            GL.DeleteProgram(m_lampShader.Handle);
            GL.DeleteProgram(m_lightingShader.Handle);

            base.OnUnload(e);
        }
    }
}