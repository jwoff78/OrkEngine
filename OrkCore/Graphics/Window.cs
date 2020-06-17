using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using OrkEngine.Graphics.Common;

namespace OrkEngine.Graphics
{
    // This tutorial is split up into multiple different bits, one for each type of light.

    // The following is the code for the directional light, a light that has a direction but no position.
    public class Window : GameWindow
    {
        // We draw multiple different cubes and it helps to store all
        // their positions in an array for later when we want to draw them
        private readonly Vector3[] _cubePositions =
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(2.0f, 5.0f, -15.0f),
            new Vector3(-1.5f, -2.2f, -2.5f),
            new Vector3(-3.8f, -2.0f, -12.3f),
            new Vector3(2.4f, -0.4f, -3.5f),
            new Vector3(-1.7f, 3.0f, -7.5f),
            new Vector3(1.3f, -2.0f, -2.5f),
            new Vector3(1.5f, 2.0f, -2.5f),
            new Vector3(1.5f, 0.2f, -1.5f),
            new Vector3(-1.3f, 1.0f, -1.5f)
        };

        private readonly Vector3 _lightPos = new Vector3(1.2f, 1.0f, 2.0f);

        public Model cube;

        private int _vaoLamp;

        private Shader _lampShader;

        private Shader _lightingShader;

        //private Texture _diffuseMap;

        private Texture _specularMap;

        public Camera camera;

        public double deltaTime;

        private bool _firstMove = true;

        private Vector2 _lastPos;

        Func<object> Start, Update;

        public Window(int width, int height, string title, Func<object> start, Func<object> update)
            : base(width, height, GraphicsMode.Default, title)
        {
            Start = start; Update = update;
        }

        protected override void OnLoad(EventArgs e)
        {
            cube = Model.LoadModelFromFile("Earth 2K.obj");
            cube.texture = new Texture("Textures/Diffuse_2K.png");

            GL.ClearColor(0.05f, 0.05f, 0.07f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            cube.vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, cube.vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, cube.vertices.Length * sizeof(float), cube.vertices, BufferUsageHint.StaticDraw);

            _lightingShader = new Shader("Graphics/Shaders/shader.vert", "Graphics/Shaders/lighting.frag");
            _lampShader = new Shader("Graphics/Shaders/shader.vert", "Graphics/Shaders/shader.frag");
            //_diffuseMap = new Texture("Graphics/Default/default.png");
            _specularMap = new Texture("C:/Users/User/Desktop/blank.png");

            cube.vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(cube.vertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, cube.vertexBufferObject);

            var positionLocation = _lightingShader.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(positionLocation);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

            var normalLocation = _lightingShader.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(normalLocation);
            GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

            var texCoordLocation = _lightingShader.GetAttribLocation("aTexCoords");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));

            _vaoLamp = GL.GenVertexArray();
            GL.BindVertexArray(_vaoLamp);

            GL.BindBuffer(BufferTarget.ArrayBuffer, cube.vertexBufferObject);

            positionLocation = _lampShader.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(positionLocation);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

            camera = new Camera(Vector3.UnitZ * 3, Width / (float)Height);

            CursorVisible = false;

            Start();

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(cube.vertexArrayObject);

            cube.texture.Use();
            _specularMap.Use(TextureUnit.Texture1);
            _lightingShader.Use();

            _lightingShader.SetMatrix4("view", camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", camera.GetProjectionMatrix());

            _lightingShader.SetVector3("viewPos", camera.Position);

            _lightingShader.SetInt("material.diffuse", 0);
            _lightingShader.SetInt("material.specular", 1);
            _lightingShader.SetVector3("material.specular", new Vector3(0.5f, 0.5f, 0.5f));
            _lightingShader.SetFloat("material.shininess", 32);

            // Directional light needs a direction, in this example we just use (-0.2, -1.0, -0.3f) as the lights direction
            _lightingShader.SetVector3("light.direction", new Vector3(-0.2f, -1.0f, -0.3f));
            _lightingShader.SetVector3("light.ambient", new Vector3(0.2f));
            _lightingShader.SetVector3("light.diffuse", new Vector3(0.5f));
            _lightingShader.SetVector3("light.specular", new Vector3(1.0f));

            // We want to draw all the cubes at their respective positions
            for (int i = 0; i < _cubePositions.Length; i++)
            {
                // First we create a model from an identity matrix
                Matrix4 model = Matrix4.Identity;
                // Then we translate said matrix by the cube position
                model *= Matrix4.CreateTranslation(_cubePositions[i]);
                // We then calculate the angle and rotate the model around an axis
                float angle = 20.0f * i;
                model *= Matrix4.CreateFromAxisAngle(new Vector3(1.0f, 0.3f, 0.5f), angle);
                model *= Matrix4.CreateScale(0.5f);
                // Remember to set the model at last so it can be used by opentk
                _lightingShader.SetMatrix4("model", model);

                // At last we draw all our cubes
                GL.DrawArrays(PrimitiveType.Quads, 0, cube.vertices.Length / 8);
            }

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        public void AddToRenderQueue(Model m)
        {

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (!Focused)
            {
                return;
            }

            deltaTime = e.Time;
            Update();

            base.OnUpdateFrame(e);
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

            GL.DeleteBuffer(cube.vertexBufferObject);
            GL.DeleteVertexArray(cube.vertexArrayObject);
            GL.DeleteVertexArray(_vaoLamp);

            GL.DeleteProgram(_lampShader.Handle);
            GL.DeleteProgram(_lightingShader.Handle);

            base.OnUnload(e);
        }
    }
}