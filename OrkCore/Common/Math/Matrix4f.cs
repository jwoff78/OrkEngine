﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
	public class Matrix4f
	{
		private float[,] m;

		public Matrix4f()
		{
			m = new float[4, 4];
		}

		public Matrix4f InitIdentity()
		{
			m[0, 0] = 1; m[0, 1] = 0; m[0, 2] = 0; m[0, 3] = 0;
			m[1, 0] = 0; m[1, 1] = 1; m[1, 2] = 0; m[1, 3] = 0;
			m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = 1; m[2, 3] = 0;
			m[3, 0] = 0; m[3, 1] = 0; m[3, 2] = 0; m[3, 3] = 1;

			return this;
		}

		public Matrix4f InitTranslation(float x, float y, float z)
		{
			m[0, 0] = 1; m[0, 1] = 0; m[0, 2] = 0; m[0, 3] = x;
			m[1, 0] = 0; m[1, 1] = 1; m[1, 2] = 0; m[1, 3] = y;
			m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = 1; m[2, 3] = z;
			m[3, 0] = 0; m[3, 1] = 0; m[3, 2] = 0; m[3, 3] = 1;

			return this;
		}

		public Matrix4f InitRotation(float x, float y, float z)
		{
			Matrix4f rx = new Matrix4f();
			Matrix4f ry = new Matrix4f();
			Matrix4f rz = new Matrix4f();

			x = (float)ToRadians(x);
			y = (float)ToRadians(y);
			z = (float)ToRadians(z);

			rz.m[0, 0] = (float)Math.Cos(z); rz.m[0, 1] = -(float)Math.Sin(z); rz.m[0, 2] = 0; rz.m[0, 3] = 0;
			rz.m[1, 0] = (float)Math.Sin(z); rz.m[1, 1] = (float)Math.Cos(z); rz.m[1, 2] = 0; rz.m[1, 3] = 0;
			rz.m[2, 0] = 0; rz.m[2, 1] = 0; rz.m[2, 2] = 1; rz.m[2, 3] = 0;
			rz.m[3, 0] = 0; rz.m[3, 1] = 0; rz.m[3, 2] = 0; rz.m[3, 3] = 1;

			rx.m[0, 0] = 1; rx.m[0, 1] = 0; rx.m[0, 2] = 0; rx.m[0, 3] = 0;
			rx.m[1, 0] = 0; rx.m[1, 1] = (float)Math.Cos(x); rx.m[1, 2] = -(float)Math.Sin(x); rx.m[1, 3] = 0;
			rx.m[2, 0] = 0; rx.m[2, 1] = (float)Math.Sin(x); rx.m[2, 2] = (float)Math.Cos(x); rx.m[2, 3] = 0;
			rx.m[3, 0] = 0; rx.m[3, 1] = 0; rx.m[3, 2] = 0; rx.m[3, 3] = 1;

			ry.m[0, 0] = (float)Math.Cos(y); ry.m[0, 1] = 0; ry.m[0, 2] = -(float)Math.Sin(y); ry.m[0, 3] = 0;
			ry.m[1, 0] = 0; ry.m[1, 1] = 1; ry.m[1, 2] = 0; ry.m[1, 3] = 0;
			ry.m[2, 0] = (float)Math.Sin(y); ry.m[2, 1] = 0; ry.m[2, 2] = (float)Math.Cos(y); ry.m[2, 3] = 0;
			ry.m[3, 0] = 0; ry.m[3, 1] = 0; ry.m[3, 2] = 0; ry.m[3, 3] = 1;

			m = rz.Mul(ry.Mul(rx)).GetM();

			return this;
		}

		public Matrix4f InitScale(float x, float y, float z)
		{
			m[0, 0] = x; m[0, 1] = 0; m[0, 2] = 0; m[0, 3] = 0;
			m[1, 0] = 0; m[1, 1] = y; m[1, 2] = 0; m[1, 3] = 0;
			m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = z; m[2, 3] = 0;
			m[3, 0] = 0; m[3, 1] = 0; m[3, 2] = 0; m[3, 3] = 1;

			return this;
		}

		public Matrix4f InitPerspective(float fov, float aspectRatio, float zNear, float zFar)
		{
			float tanHalfFOV = (float)Math.Tan(fov / 2);
			float zRange = zNear - zFar;

			m[0, 0] = 1.0f / ( tanHalfFOV * aspectRatio ); m[0, 1] = 0; m[0, 2] = 0; m[0, 3] = 0;
			m[1, 0] = 0; m[1, 1] = 1.0f / tanHalfFOV; m[1, 2] = 0; m[1, 3] = 0;
			m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = ( -zNear - zFar ) / zRange; m[2, 3] = 2 * zFar * zNear / zRange;
			m[3, 0] = 0; m[3, 1] = 0; m[3, 2] = 1; m[3, 3] = 0;


			return this;
		}

		public Matrix4f InitOrthographic(float left, float right, float bottom, float top, float near, float far)
		{
			float width = right - left;
			float height = top - bottom;
			float depth = far - near;

			m[0, 0] = 2 / width; m[0, 1] = 0; m[0, 2] = 0;          m[0, 3] = -( right + left ) / width;
			m[1, 0] = 0;         m[1, 1] = 2 / height;              m[1, 2] = 0;  m[1, 3] = -( top + bottom ) / height;
			m[2, 0] = 0;         m[2, 1] = 0; m[2, 2] = -2 / depth; m[2, 3] = -( far + near ) / depth;
			m[3, 0] = 0;         m[3, 1] = 0;                       m[3, 2] = 0; m[3, 3] = 1;

			return this;
		}

		public Matrix4f InitRotation(Vector3f forward, Vector3f up)
		{
			Vector3f f = forward.Normalized();

			Vector3f r = up.Normalized();
			r = r.Cross(f);

			Vector3f u = f.Cross(r);

			return InitRotation(f, u, r);
		}

		public Matrix4f InitRotation(Vector3f forward, Vector3f up, Vector3f right)
		{
			Vector3f f = forward;
			Vector3f r = right;
			Vector3f u = up;

			m[0, 0] = r.X; m[0, 1] = r.Y; m[0, 2] = r.Z; m[0, 3] = 0;
			m[1, 0] = u.X; m[1, 1] = u.Y; m[1, 2] = u.Z; m[1, 3] = 0;
			m[2, 0] = f.X; m[2, 1] = f.Y; m[2, 2] = f.Z; m[2, 3] = 0;
			m[3, 0] = 0;   m[3, 1] = 0;   m[3, 2] = 0;   m[3, 3] = 1;

			return this;
		}

		public Vector3f Transform(Vector3f r)
		{
			return new Vector3f(m[0, 0] * r.X + m[0, 1] * r.Y + m[0, 2] * r.Z + m[0, 3],
								m[1, 0] * r.X + m[1, 1] * r.Y + m[1, 2] * r.Z + m[1, 3],
								m[2, 0] * r.X + m[2, 1] * r.Y + m[2, 2] * r.Z + m[2, 3]);
		}

		public Matrix4f Mul(Matrix4f r)
		{
			Matrix4f res = new Matrix4f();

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					res.Set(i, j, m[i, 0] * r.Get(0, j) +
						       	  m[i, 1] * r.Get(1, j) +
							      m[i, 2] * r.Get(2, j) +
							      m[i, 3] * r.Get(3, j));
				}
			}

			return res;
		}

		public float[,] GetM()
		{
			float[,] res = new float[4, 4];

			for (int i = 0; i < 4; i++)
				for (int j = 0; j < 4; j++)
					res[i, j] = m[i, j];

			return res;
		}

		public float Get(int x, int y)
		{
			return m[x, y];
		}

		public void SetM(float[,] m)
		{
			this.m = m;
		}

		public void Set(int x, int y, float value)
		{
			m[x, y] = value;
		}
		public double ToRadians(double val)
		{
			return ( Math.PI / 180 ) * val;
		}
	}
}
