using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;

namespace OrkEngine
{
    /// <summary>
    /// Represents a game.
    /// Contains a set of properties and functions used to run a game.
    /// </summary>
    public class OrkGame : GameWindow, IDisposable
    {
        // private readonly Vector3 _lightPos = new Vector3(1.2f, 1.0f, 2.0f);

        #region Fields

        private List<GameObject> m_objects = new List<GameObject>();

        private int m_vertexBufferObject;

        private int m_vaoModel;

        private int m_vaoLamp;

        private Shader m_lampShader;

        private Shader m_lightingShader;

        private Texture m_diffuseMap;

        private Texture m_specularMap;

        private GameObject m_camera;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the time from the last update.
        /// </summary>
        public double DeltaTime { get; private set; }
        /// <summary>
        /// Gets a list with all the game objects in the game.
        /// </summary>
        public IReadOnlyList<GameObject> Objects => m_objects;

        /// <summary>
        /// Gets the main camera.
        /// </summary>
        public GameObject Camera { get; private set; }
        #endregion

        #region Helpers
        /// <summary>
        /// Does a bunch of checks to make sure the whole engine is here, and also checks file health.
        /// </summary>
        private void SignatureCheck() { }
        public Matrix4 Rotate(Vector3 rot)
        {
            return Matrix4.CreateRotationX((float)Math.PI / 180 * ( rot.X )) * Matrix4.CreateRotationY((float)Math.PI / 180 * ( rot.Y )) * Matrix4.CreateRotationZ((float)Math.PI / 180 * ( rot.Z ));
        }

        public Matrix4 Translate(Vector3 pos)
        {
            return Matrix4.CreateTranslation(pos);
        }
        #endregion

        #region Game Events
        /// <summary>
        /// Gets called when the core libraries are loaded.
        /// </summary>
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

            CursorVisible = false;

           //TODO fix if (OnStart is object)
            OnStart();
            base.OnLoad(e);
        }

        /// <summary>
        /// Gets called before the game starts.
        /// </summary>
        protected virtual void OnStart() { }

        /// <summary>
        /// Gets called on every call to Update().
        /// </summary>
        protected virtual void OnUpdate(double deltaTime) { }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
           //TODO FIX if (OnUpdate is object)
                OnUpdate(e.Time);
            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            m_camera.ActionData["ASPECT"] = Width / (float)Height;
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

        /// <summary>
        /// Gets called on every call to FixedUpdate().
        /// </summary>
        protected virtual void OnFixedUpdate() { }

        /// <summary>
        /// Gets called if a late update occurs.
        /// </summary>
        protected virtual void OnLateUpdate() { }

        /// <summary>
        /// Gets called if Disable() is called.
        /// </summary>
        protected virtual void OnDisable() { }

        /// <summary>
        /// Gets called after every update on render.
        /// </summary>
        protected virtual void OnRender() { }

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

                    m_lightingShader.SetMatrix4("view", (Matrix4)m_camera.CallAction("viewMatrix", ""));
                    m_lightingShader.SetMatrix4("projection", (Matrix4)m_camera.CallAction("projectionMatrix", ""));

                    m_lightingShader.SetVector3("viewPos", m_camera.Position);

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

        #endregion

        #region Game Functions
        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start() => Run(60.0);

        public void Stop() => Exit();

        /// <summary>
        /// Disables the current game window.
        /// </summary>
        public void Disable()
        {
            // TODO: Force disabled status in the instance.
            OnDisable();
        }

        public void AddToRenderQueue(GameObject obj)
        {
            foreach (Model mod in obj.Models)
            {
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

            m_objects.Add(obj);
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

        #endregion

        #region Other Logic
        public void AddObject(GameObject gameObject)
        {
            if (gameObject is object)
               AddToRenderQueue(gameObject);
        }

        public bool KeyDown(Key key) => Keyboard.GetState().IsKeyDown(key);
        #endregion

        #region Implementation of IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dumping)
        {
            if (dumping) Dump();
        }

        /// <summary>
        /// Deletes all of the object holders.
        /// </summary>
        private void Dump()
        {

        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the OrkGame class with all the default values.
        /// </summary>
        public OrkGame() : this("Made with OrkGame") { }

        /// <summary>
        /// Creates a new instance of the OrkGame class with a custom title and default size.
        /// </summary>
        /// <param name="title">Title of this window.</param>
        public OrkGame(string title) : this(title, 1024, 768) { }

        /// <summary>
        /// Creates a new instance of the OrkGame class with custom window properties.
        /// </summary>
        /// <param name="title">Title of this window.</param>
        /// <param name="width">Width of this window.</param>
        /// <param name="height">Height of this window.</param>
        public OrkGame(string title, int width, int height)
            : base(width, height, GraphicsMode.Default, title)
        {
            SignatureCheck();
            m_camera = GameObject.Camera(width / (float)height);
            // TODO: Initialize more stuff.
        }
        #endregion
    }
}