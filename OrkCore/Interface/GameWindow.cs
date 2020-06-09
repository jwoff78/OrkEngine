using OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tao.FreeGlut;

namespace OrkCore.Interface
{
    public class GameWindow
    {
        private static int m_width = 1280, m_height = 720;
        private static ShaderProgram program;

        List<Renderable> Objects = new List<Renderable>();

        private static Random generator = new Random(Environment.TickCount);
        private static float theta = (float)Math.PI / 2, phi = (float)Math.PI / 2;

        public static System.Diagnostics.Stopwatch watch;
        public static float angle;
        public static bool EnableLighting = true;

        public static Func<object> update;

        public void CreateWindow(Func<object> Start, Func<object> Update, string title = "OrkGameEngine", int width = 1280, int height = 720)
        {
            m_width = width;
            m_height = height;

            update = Update;
            // create an OpenGL window
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH | Glut.GLUT_RGBA);
            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow(title);

            // provide the Glut callbacks that are necessary for running this tutorial
            Glut.glutIdleFunc(OnRenderFrame);
            Glut.glutDisplayFunc(OnDisplay);
            Glut.glutReshapeFunc(OnReshape);
            Glut.glutCloseFunc(OnClose);

            Gl.Enable(EnableCap.DepthTest);
            Gl.Enable(EnableCap.ProgramPointSize);
            Gl.Enable(EnableCap.Multisample);
            Gl.Enable(EnableCap.Blend);
            Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            program = new ShaderProgram(VertexShader, FragmentShader);
            program.Use();
            program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
            program["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0,0,10), Vector3.Zero, Vector3.Up));
            program["light_direction"].SetValue(new Vector3(0,0,1));


            watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Start();

            Gl.ClearColor(0f,0f,0f,0f); //sets clear color to black
            Glut.glutMainLoop();
        }

        private static void OnDisplay()
        {

        }

        private static void OnReshape(int width, int height)
        {
            GameWindow.m_width = width;
            GameWindow.m_height = height;

            program.Use();
            program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
        }

        private void OnClose()
        {
            foreach (Renderable rend in Objects)
            {
                rend.DisposeVBOs();
            }
            Objects.Clear();
            program.DisposeChildren = true;
            program.Dispose();
        }

        private void OnRenderFrame()
        {
            watch.Stop();
            float deltaTime = watch.ElapsedMilliseconds / 1000f;
            watch.Restart();

            angle += deltaTime;

            // set up the OpenGL viewport and clear both the color and depth bits
            Gl.Viewport(0, 0, m_width, m_height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            program.Use();
            /*Gl.BindTexture(CubeTex);

            //cube
            program["model_matrix"].SetValue(Matrix4.CreateRotationY(angle / 2) * Matrix4.CreateRotationX(angle));
            Gl.BindBufferToShaderAttribute(cube, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(cubeNormals, program, "vertexNormal");
            Gl.BindBufferToShaderAttribute(cubeUV, program, "vertexUV");
            Gl.BindBuffer(cubeQuads);

            Gl.DrawElements(BeginMode.Quads, cubeQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);*/

            foreach (Renderable rend in Objects)
            {
                Gl.BindTexture(rend.texture);

                program["model_matrix"].SetValue(Matrix4.CreateRotationX(rend.rotation.x) * Matrix4.CreateRotationY(rend.rotation.y) * Matrix4.CreateRotationZ(rend.rotation.z) * Matrix4.CreateTranslation(rend.position));
                Gl.BindBufferToShaderAttribute((VBO<Vector3>)rend.GetVBOs[0], program, "vertexPosition");
                Gl.BindBufferToShaderAttribute((VBO<Vector3>)rend.GetVBOs[1], program, "vertexNormal");
                Gl.BindBufferToShaderAttribute((VBO<Vector2>)rend.GetVBOs[2], program, "vertexUV");
                Gl.BindBuffer((VBO<uint>)rend.GetVBOs[3]);

                Gl.DrawElements(rend.beginmode, rend.elements.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
            }

            Glut.glutSwapBuffers();

            update();
        }

        public void AddRenderable(Renderable obj)
        {
            Objects.Add(obj);
            Console.WriteLine("Added : " + obj.name);
        }

        public static string VertexShader =
            @"
                #version 130
                in vec3 vertexPosition;
                in vec3 vertexNormal;
                in vec2 vertexUV;

                out vec3 normal;
                out vec2 uv;

                uniform mat4 projection_matrix;
                uniform mat4 view_matrix;
                uniform mat4 model_matrix;

                void main(void)
                {
                    normal = normalize((model_matrix * vec4(vertexNormal, 0)).xyz);
                    uv = vertexUV;
                    gl_Position = projection_matrix * view_matrix * model_matrix * vec4(vertexPosition, 1);
                }
            ";

        public static string FragmentShader =
            @"
                #version 130

                uniform sampler2D texture;
                uniform vec3 light_direction;

                in vec3 normal;
                in vec2 uv;

                out vec4 fragment;

                void main(void)
                {
                    float diffuse = max(dot(normal, light_direction), 0);
                    float ambient = 0.3;
                    float lighting = max(diffuse, ambient);
                    vec4 sample = texture2D(texture, uv);
                    fragment = vec4(lighting * sample.xyz, sample.a);
                }
            ";
    }
}
