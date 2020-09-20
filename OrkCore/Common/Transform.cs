using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrkEngine.GameObject;

namespace OrkEngine
{
    public class Transform
    {

        public List<GameObject> Children = new List<GameObject>();
        public TransformOffset Offset = new TransformOffset();
        private Vector3 m_pos = new Vector3(0,0,0);
        private Vector3 m_rotation = new Vector3(0,0,0);
        private Vector3 m_scale    = new Vector3(1,1,1);

        public Vector3 Position
        {
            get { return m_pos; }
            set
            {
                m_pos = value;
                foreach (GameObject g in Children)
                {
                    g.Offset.Position = m_pos;
                }
            }
        }

        public Vector3 Rotation
        {
            get { return m_rotation; }
            set
            {
                m_rotation = value;
                foreach (GameObject g in Children)
                {
                    g.Offset.Rotation = value;
                }
            }
        }

        public Vector3 Scale
        {
            get { return m_scale; }
            set
            {
                m_scale = value;
                foreach (GameObject g in Children)
                {
                    g.Offset.Scale = m_scale;
                    g.Offset.Position *= m_scale;
                }
            }
        }

        public Vector3 Forward
        {
            get
            {
                return ( Quaternion.FromEulerAngles(m_rotation) + Quaternion.FromEulerAngles(Offset.Rotation) ).Normalized() * -Vector3.UnitZ;
            }
        }

        public Vector3 Up
        {
            get
            {
                return ( Quaternion.FromEulerAngles(m_rotation) + Quaternion.FromEulerAngles(Offset.Rotation) ).Normalized() * Vector3.UnitY;
            }
        }

        public Vector3 Right
        {
            get
            {
                return ( Quaternion.FromEulerAngles(m_rotation) + Quaternion.FromEulerAngles(Offset.Rotation) ).Normalized() * Vector3.UnitX;
            }
        }

        public Vector3 LocalForward
        {
            get
            {
                return ( Quaternion.FromEulerAngles(m_rotation) ).Normalized() * -Vector3.UnitZ;
            }
        }

        public struct TransformOffset
        {
            public Vector3 Position;
            public Vector3 Rotation;
            public Vector3 Scale;
        }

        public Vector3 RotateAroundParent()
        {
            float distance = Vector3.Distance(Position, Offset.Position);
            Vector3 rotationInRads = new Vector3((float)Math.PI / 180 * Offset.Rotation.X, (float)Math.PI / 180 * Offset.Rotation.Y, (float)Math.PI / 180 * Offset.Rotation.Z);
            Vector3 v3 = new Vector3(
                (float)(distance * Math.Cos(rotationInRads.X) * Math.Cos(rotationInRads.Y)),
                (float)(distance * Math.Cos(rotationInRads.X) * Math.Sin(rotationInRads.Y)),
                (float)(distance * Math.Sin(rotationInRads.Y))
                );
            return v3;
        }
    }
}
