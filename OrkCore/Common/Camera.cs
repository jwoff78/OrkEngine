using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrkEngine
{
    public abstract class Camera
    {
        private static Vector3 m_up = Vector3.UnitY;
        private static float m_maxZ;
        private static float m_minZ;



        /// <summary>
		/// Gets the cameras view matrix.
		/// </summary>
		public abstract Matrix4 ViewMatrix { get; }

        /// <summary>
        /// Gets the cameras projection matrix.
        /// </summary>
        public abstract Matrix4 ProjectionMatrix { get; }

        public float MaxZ
        {
            get
            {
                return m_maxZ;
            }
            set
            {
                m_maxZ = value;
            }
        }

        public float MinZ
        {
            get
            {
                return m_minZ;
            }
            set
            {
                m_minZ = value;
            }
        }

        /// <summary>
        /// Gets or sets the screen area the camera renders to.
        /// </summary>
        public Box2 Area
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the up direction all cameras share.
        /// </summary>
        public static Vector3 Up
        {
            get
            {
                return Camera.m_up;
            }
            set
            {
                Camera.m_up = value;
            }
        }

        /// <summary>
		/// Gets the camera viewport.
		/// </summary>
        public Box2 GetViewport()
        {
            Box2 area = Area;

            if (area.Width < 1.0f || area.Height < 1.0f)
            {
                //TODO engine width and height for last 2 zeros
                area = new Box2(0, 0, 0, 0);
            }

            return area;
        }

        /// <summary>
		/// Constructs a ray from a screen position.
		/// </summary>
		/// <param name="x">X coordinate</param>
		/// <param name="y">Y coordinate</param>
		/// <returns>Constructed ray.</returns>
        public Ray CreateRay(int x, int y)
        {
            Box2 viewport = GetViewport();

            //pain in my ass
            float fx = 2.0f * (x - viewport.Left) / viewport.Width - 1.0f;
            float fy = 1.0f - 2.0f * (y - viewport.Top) / viewport.Height;

            //might be unstable
            Vector3 from = Unproject(new Vector3(fx, fy, 0.0f));
            Vector3 to = Unproject(new Vector3(fx, fy, 1.0f));
            //Vector3.Unproject()
            return new Ray(from, to - from);

        }

        public Vector3 Unproject(Vector3 worldCoord)
        {
            //TODO might need fixed
            return Vector3.Unproject(worldCoord, worldCoord.X, worldCoord.Y, Area.Height, Area.Width, MinZ, MaxZ, ProjectionMatrix);
        }
    }
    /*
    public class Camera
    {
        private Vector3 m_front = -Vector3.UnitZ;

        private Vector3 m_up = Vector3.UnitY;

        private Vector3 m_right = Vector3.UnitX;

        private float m_pitch;

        private float m_yaw = -MathHelper.PiOver2;

        private float m_fov = MathHelper.PiOver2;

        public Camera(Vector3 position, float aspectRatio)
        {
            Position = position;
            AspectRatio = aspectRatio;
        }

        public Vector3 Position { get; set; }

        public float AspectRatio { private get; set; }

        public Vector3 Front => m_front;

        public Vector3 Up => m_up;

        public Vector3 Right => m_right;

        public bool LookAtMode = false;

        public Vector3 LookTarget = new Vector3(0,0,0);

        public float Pitch
        {
            get => MathHelper.RadiansToDegrees(m_pitch);
            set
            {
                var angle = MathHelper.Clamp(value, -89f, 89f);
                m_pitch = MathHelper.DegreesToRadians(angle);
                UpdateVectors();
            }
        }

        public float Yaw
        {
            get => MathHelper.RadiansToDegrees(m_yaw);
            set
            {
                m_yaw = MathHelper.DegreesToRadians(value);
                UpdateVectors();
            }
        }

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(m_fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 45f);
                m_fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public Matrix4 GetViewMatrix()
        {
            if (!LookAtMode) {
                return Matrix4.LookAt(Position, Position + m_front, m_up);
            }
            else
            {
                return Matrix4.LookAt(Position, LookTarget, m_up);
            }
        }
        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(m_fov, AspectRatio, 0.1f, 100);
        }

        private void UpdateVectors()
        {
            m_front.X = (float)Math.Cos(m_pitch) * (float)Math.Cos(m_yaw);
            m_front.Y = (float)Math.Sin(m_pitch);
            m_front.Z = (float)Math.Cos(m_pitch) * (float)Math.Sin(m_yaw);

            m_front = Vector3.Normalize(m_front);

            m_right = Vector3.Normalize(Vector3.Cross(m_front, Vector3.UnitY));
            m_up = Vector3.Normalize(Vector3.Cross(m_right, m_front));
        }
    }
    */
}