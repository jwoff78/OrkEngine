using System;
using OpenTK;

namespace OrkEngine.Graphics.Common
{
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
}