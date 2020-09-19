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
        internal List<GameObject> Objects = new List<GameObject>();

        // private readonly Vector3 _lightPos = new Vector3(1.2f, 1.0f, 2.0f);

        #region Private Fields
        private int m_vertexBufferObject;

        private int m_vaoModel;

        private int m_vaoLamp;

        private Shader m_lampShader;

        private Shader m_lightingShader;

        private Texture _diffuseMap;

        private Texture _specularMap;

        private GameObject m_camera;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the time from the last update.
        /// </summary>
        public double DeltaTime { get; private set; }
        #endregion

        #region OrkWindow Events
        internal Action OnStart { get; set; }

        internal Action<double> OnUpdate { get; set; }
        #endregion

        #region Helpers
        public Matrix4 Rotate(Vector3 rot)
        {
            return Matrix4.CreateRotationX((float)Math.PI / 180 * (rot.X)) * Matrix4.CreateRotationY((float)Math.PI / 180 * (rot.Y)) * Matrix4.CreateRotationZ((float)Math.PI / 180 * (rot.Z));
        }

        public Matrix4 Translate(Vector3 pos)
        {
            return Matrix4.CreateTranslation(pos);
        }
        #endregion

        #region Events
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(139 / 255f, 182 / 255f, 201 / 255f, 1.0f);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            //GL.Enable(EnableCap.CullFace);

            m_lightingShader = new Shader("Graphics/Shaders/shader.vert", "Graphics/Shaders/lighting.frag");
            m_lampShader = new Shader("Graphics/Shaders/shader.vert", "Graphics/Shaders/shader.frag");
            _diffuseMap = new Texture("Textures/Diffuse_2K.png");
            _specularMap = new Texture("Textures/Bump_2K.png");

            CursorVisible = false;

            if (OnStart is object)
                OnStart();
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

                if (obj.modelIndex > obj.models.Count - 1)
                {
                    mod = obj.models[0];
                    Console.WriteLine("[!] Model Index {0} was out of bounds. GameObject: {1}", obj.modelIndex, obj.name);
                }
                else
                    mod = obj.ActiveModel;

                foreach (Mesh m in mod.meshes)
                {
                    GL.BindVertexArray(m.vertexArrayObject);

                    m.material.diffuseMap.Use();
                    m.material.specularMap.Use(TextureUnit.Texture1);
                    m_lightingShader.Use();

                    m_lightingShader.SetMatrix4("view", (Matrix4)m_camera.callAction("viewMatrix", ""));
                    m_lightingShader.SetMatrix4("projection", (Matrix4)m_camera.callAction("projectionMatrix", ""));

                    m_lightingShader.SetVector3("viewPos", m_camera.position);

                    m_lightingShader.SetInt("material.diffuse", 0);
                    m_lightingShader.SetInt("material.specular", 1);
                    m_lightingShader.SetVector3("material.specular", m.material.specular);
                    m_lightingShader.SetFloat("material.shininess", m.material.shininess);

                    Matrix4 model = Matrix4.Identity;

                    model *= Rotate(obj.rotation); // obj rotation
                    model *= Translate(obj.position); // object position
                    model *= Matrix4.CreateScale(obj.scale); // object scale

                    model *= Rotate(obj.offset.rot); // parent rotation
                    model *= Translate(obj.offset.pos); // parent position
                    model *= Matrix4.CreateScale(obj.offset.scl); // parent scale

                    m_lightingShader.SetMatrix4("model", model);

                    GL.DrawArrays((PrimitiveType)mod.renderMode, 0, m.vertices.Length / 8);
                    GL.BindVertexArray(0);
                }
            }

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (OnUpdate is object)
                OnUpdate(e.Time);
            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            m_camera.actionData["ASPECT"] = Width / (float)Height;
            base.OnResize(e);
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
        #endregion

        #region Public Functions
        public void AddToRenderQueue(GameObject obj)
        {
            foreach (Model mod in obj.models) {
                foreach (Mesh m in mod.meshes)
                {
                    m.vertexBufferObject = GL.GenBuffer();
                    GL.BindBuffer(BufferTarget.ArrayBuffer, m.vertexBufferObject);
                    GL.BufferData(BufferTarget.ArrayBuffer, m.vertices.Length * sizeof(float), m.vertices, BufferUsageHint.StaticDraw);

                    m.vertexArrayObject = GL.GenVertexArray();
                    GL.BindVertexArray(m.vertexArrayObject);

                    GL.BindBuffer(BufferTarget.ArrayBuffer, m.vertexBufferObject);

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
            Console.WriteLine("Added: " + obj.name);
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
                foreach (Model mod in obj.models)
                    foreach (Mesh m in mod.meshes)
                    {
                        GL.DeleteBuffer(m.vertexBufferObject);
                        GL.DeleteVertexArray(m.vertexArrayObject);
                        GL.DeleteTexture(m.material.diffuseMap.Handle);
                    }
        }
        #endregion

        internal Window(string title, int width, int height, GameObject camera) 
            : base(width, height, GraphicsMode.Default, title) 
           => m_camera = camera;
    }
}