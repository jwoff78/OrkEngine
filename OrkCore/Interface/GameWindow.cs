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

        private static VBO<Vector3> cube;
        private static VBO<uint> cubeQuads;
        private static VBO<Vector2> cubeUV;
        private static VBO<Vector3> cubeNormals;
        private static Texture CubeTex;

        private static VBO<Vector3> particle;
        private static VBO<Vector2> particleUV;
        private static VBO<uint> particleQuads;
        private static Texture particleTexture;

        private static List<Particle> particles = new List<Particle>();

        private static Random generator = new Random(Environment.TickCount);
        private static float theta = (float)Math.PI / 2, phi = (float)Math.PI / 2;

        public static System.Diagnostics.Stopwatch watch;
        public static float angle;
        public static bool EnableLighting = true;


        static float xOff = -1.5f;
        static bool mode = true;

        private class Particle
        {
            public float angle;
            public float dist;
            public Vector3 color;

            public Particle(float Angle, float Distance, Vector3 Color)
            {
                this.angle = Angle;
                this.dist = Distance;
                this.color = Color;
            }
        }

        public void CreateWindow(string title = "JarJarGE", int width = 1280, int height = 720)
        {
            m_width = width;
            m_height = height;
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

            CubeTex = new Texture(@"vroooom.png");

            //Cube Setup
            {
                cube = new VBO<Vector3>(new Vector3[] {
                    new Vector3(1, 1, -1), new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1),
                    new Vector3(1, -1, 1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1), new Vector3(1, -1, -1),
                    new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1),
                    new Vector3(1, -1, -1), new Vector3(-1, -1, -1), new Vector3(-1, 1, -1), new Vector3(1, 1, -1),
                    new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, -1), new Vector3(-1, -1, 1),
                    new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1) });
                cubeUV = new VBO<Vector2>(new Vector2[] {
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) });
                cubeNormals = new VBO<Vector3>(new Vector3[] {
                    new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0),
                    new Vector3(0, -1, 0), new Vector3(0, -1, 0), new Vector3(0, -1, 0), new Vector3(0, -1, 0),
                    new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 1),
                    new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1),
                    new Vector3(-1, 0, 0), new Vector3(-1, 0, 0), new Vector3(-1, 0, 0), new Vector3(-1, 0, 0),
                    new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0) });
                cubeQuads = new VBO<uint>(new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }, BufferTarget.ElementArrayBuffer);
            }

            particle = new VBO<Vector3>(new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0), new Vector3(1, 1, 0), new Vector3(-1, 1, 0) });
            particleUV = new VBO<Vector2>(new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) });
            particleQuads = new VBO<uint>(new uint[] { 0, 1, 2, 0, 2, 3 }, BufferTarget.ElementArrayBuffer);

            // create 50 particles for this tutorial
            int numparticles = 50;
            for (int i = 0; i < numparticles; i++)
            {
                particles.Add(new Particle(0, (float)i / numparticles * 4f, new Vector3((float)generator.NextDouble(), (float)generator.NextDouble(), (float)generator.NextDouble())));
            }

            watch = new System.Diagnostics.Stopwatch();
            watch.Start();

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

        private static void OnClose()
        {
            cube.Dispose();
            cubeUV.Dispose();
            cubeQuads.Dispose();
            CubeTex.Dispose();
            cubeNormals.Dispose();
            particle.Dispose();
            particleUV.Dispose();
            particleQuads.Dispose();
            program.DisposeChildren = true;
            program.Dispose();
        }

        private static void OnRenderFrame()
        {
            watch.Stop();
            float deltaTime = watch.ElapsedMilliseconds / 1000f;
            watch.Restart();

            angle += deltaTime;

            // set up the OpenGL viewport and clear both the color and depth bits
            Gl.Viewport(0, 0, m_width, m_height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            program.Use();
            Gl.BindTexture(CubeTex);

            //cube
            program["model_matrix"].SetValue(Matrix4.CreateRotationY(angle / 2) * Matrix4.CreateRotationX(angle));
            Gl.BindBufferToShaderAttribute(cube, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(cubeNormals, program, "vertexNormal");
            Gl.BindBufferToShaderAttribute(cubeUV, program, "vertexUV");
            Gl.BindBuffer(cubeQuads);

            Gl.DrawElements(BeginMode.Quads, cubeQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            /*for (int i = 0; i < particles.Count; i++)
            {
                // set the position and color of this star
                program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(particles[i].dist, 0, 0)) * Matrix4.CreateRotationZ(particles[i].angle));
                program["color"].SetValue(particles[i].color);

                Gl.BindBufferToShaderAttribute(particle, program, "vertexPosition");
                Gl.BindBufferToShaderAttribute(particleUV, program, "vertexUV");
                Gl.BindBuffer(particleQuads);

                Gl.DrawElements(BeginMode.Triangles, particleQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

                // update the position of the star
                particles[i].angle += (float)i / particles.Count * deltaTime * 2;
                particles[i].dist -= 0.2f * deltaTime;

                // if we've reached the center then move this star outwards and give it a new color
                if (particles[i].dist < 0f)
                {
                    particles[i].dist += 5f;
                    particles[i].color = new Vector3((float)generator.NextDouble(), (float)generator.NextDouble(), (float)generator.NextDouble());
                }
            }*/

            Glut.glutSwapBuffers();
            //PosSwitcher();
        }

        static void PosSwitcher()
        {
            if (mode)
                xOff += 0.01f;
            else
                xOff -= 0.01f;

            if (xOff > 1.5f || xOff < -1.5f)
                mode = !mode;
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
