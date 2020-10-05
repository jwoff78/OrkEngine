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
        private Transform m_parent;
        private Matrix4f   m_parentMatrix;

        private Vector3f   m_position;
        private Quaternion m_rotation;
        private Vector3f   m_scale;

        private Vector3f   m_oldPosition;
        private Quaternion m_oldRotation;
        private Vector3f   m_oldScale;

        public Transform()
        {
            m_position = new Vector3f(0, 0, 0);
            m_rotation = new Quaternion(0, 0, 0, 1);
            m_scale = new Vector3f(1, 1, 1);

            m_parentMatrix = new Matrix4f().InitIdentity();
        }

        public void Update()
        {
            if (m_oldPosition != null)
            {
                m_oldPosition.Set(m_position);
                m_oldRotation.Set(m_rotation);
                m_oldScale.Set(m_scale);
            }
            else
            {
                m_oldPosition = new Vector3f(0, 0, 0).Set(m_position).Add(1.0f);
                m_oldRotation = new Quaternion(0, 0, 0, 0).Set(m_rotation).Mul(0.5f);
                m_oldScale = new Vector3f(0, 0, 0).Set(m_scale).Add(1.0f);
            }
        }

        public void Rotate(Vector3f axis, float angle)
        {
            m_rotation = new Quaternion(axis, angle).Mul(m_rotation).Normalized();
        }

        public void LookAt(Vector3f point, Vector3f up)
        {
            m_rotation = GetLookAtRotation(point, up);
        }

        public Quaternion GetLookAtRotation(Vector3f point, Vector3f up)
        {
            return new Quaternion(new Matrix4f().InitRotation(point.Sub(m_position).Normalized(), up));
        }

        public bool HasChanged()
        {
            if (m_parent != null && m_parent.HasChanged())
                return true;

            if (!m_position.Equals(m_oldPosition))
                return true;

            if (!m_rotation.Equals(m_oldRotation))
                return true;

            if (!m_scale.Equals(m_oldScale))
                return true;

            return false;
        }

        public Matrix4f GetTransformation()
        {
            Matrix4f translationMatrix = new Matrix4f().InitTranslation(m_position.X, m_position.Y, m_position.Z);
            Matrix4f rotationMatrix = m_rotation.ToRotationMatrix();
            Matrix4f scaleMatrix = new Matrix4f().InitScale(m_scale.X, m_scale.Y, m_scale.Z);

            return GetParentMatrix().Mul(translationMatrix.Mul(rotationMatrix.Mul(scaleMatrix)));
        }


        private Matrix4f GetParentMatrix()
        {
            if (m_parent != null && m_parent.HasChanged())
                m_parentMatrix = m_parent.GetTransformation();

            return m_parentMatrix;
        }

        public void SetParent(Transform parent)
        {
            m_parent = parent;
        }

        public Vector3f GetTransformedPos()
        {
            return GetParentMatrix().Transform(m_position);
        }

        public Quaternion GetTransformedRot()
        {
            Quaternion parentRotation = new Quaternion(0,0,0,1);

            if (m_parent != null)
                parentRotation = m_parent.GetTransformedRot();

            return parentRotation.Mul(m_rotation);
        }

        public Vector3f Position
        {
            get
            {
                return m_position;
            }

            set
            {
                m_position = value;
            }
        }

        public Quaternion Rotation
        {
            get
            {
                return m_rotation;
            }

            set
            {
                m_rotation = value;
            }
        }

        public Vector3f Scale
        {
            get
            {
                return m_scale;
            }

            set
            {
                m_scale = value;
            }
        }


    }

    /*
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
    */
}
