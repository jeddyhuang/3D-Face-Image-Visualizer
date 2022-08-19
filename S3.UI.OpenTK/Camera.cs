using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace S3.UI.OpenTK
{
    public static class Extension
    {
        private const double DegreeToRadian = Math.PI / 180.0f;

        public static double ToRadian(this float degree)
        {
            return degree * DegreeToRadian;
        }
    }


    public class Camera
    {
        private Vector3 _eye;
        private Vector3 _look;
        private Vector3 _up;

        private Vector3 _u;
        private Vector3 _v;
        private Vector3 _n;



        public void Set(Vector3 eye, Vector3 look)
        {
            Set(eye, look, Vector3.UnitY);
        }

        private void Set(Vector3 eye, Vector3 look, Vector3 up)
        {
            _eye = eye;
            _look = look;
            _up = up;

            _n = new Vector3(_eye.X - _look.X, _eye.Y - _look.Y, _eye.Z - _look.Z);
            _u = new Vector3(Vector3.Cross(_up, _n));
            _v = new Vector3(Vector3.Cross(_n, _u));

            _u.Normalize();
            _v.Normalize();
            _n.Normalize();

            SetModelViewMatrix();
        }

        public void SetModelViewMatrix()
        {
            var modelView = new Matrix4
            {
                M11 = _u.X,
                M12 = _v.X,
                M13 = _n.X,
                M14 = 0,

                M21 = _u.Y,
                M22 = _v.Y,
                M23 = _n.Y,
                M24 = 0,

                M31 = _u.Z,
                M32 = _v.Z,
                M33 = _n.Z,
                M34 = 0,

                M41 = -Vector3.Dot(_eye, _u),
                M42 = -Vector3.Dot(_eye, _v),
                M43 = -Vector3.Dot(_eye, _n),
                M44 = 1.0f
            };

            //var modelview = Matrix4.LookAt(_eye, _look, _up);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref modelView);
        }

        public void SetProjectionMatrix(float viewAngle, float aspect, float near, float far)
        {
            var projection = Matrix4.CreatePerspectiveFieldOfView(viewAngle, aspect, near, far);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref projection);
        }

        public void Slide(float delU, float delV, float delN)
        {
            _eye.X += delU * _u.X + delV * _v.X + delN * _n.X;
            _eye.Y += delU * _u.Y + delV * _v.Y + delN * _n.Y;
            _eye.Z += delU * _u.Z + delV * _v.Z + delN * _n.Z;

            SetModelViewMatrix();
        }


        public void Roll(float angle)
        {
            var radian = angle.ToRadian();

            var cosAngle = Math.Cos(radian);
            var sinAngle = Math.Sin(radian);

            var tempU = new Vector3(_u);
            _u = new Vector3((float)(cosAngle * tempU.X - sinAngle * _v.X), (float)(cosAngle * tempU.Y - sinAngle * _v.Y), (float)(cosAngle * tempU.Z - sinAngle * _v.Z));
            _v = new Vector3((float)(sinAngle * tempU.X + cosAngle * _v.X), (float)(sinAngle * tempU.Y + cosAngle * _v.Y), (float)(sinAngle * tempU.Z + cosAngle * _v.Z));

            SetModelViewMatrix();
        }


        public void Pitch(float angle)
        {
            var radian = angle.ToRadian();

            var cosAngle = Math.Cos(radian);
            var sinAngle = Math.Sin(radian);

            var tempN = new Vector3(_n);
            _n = new Vector3((float)(cosAngle * tempN.X - sinAngle * _v.X), (float)(cosAngle * tempN.Y - sinAngle * _v.Y), (float)(cosAngle * tempN.Z - sinAngle * _v.Z));
            _v = new Vector3((float)(sinAngle * tempN.X + cosAngle * _v.X), (float)(sinAngle * tempN.Y + cosAngle * _v.Y), (float)(sinAngle * tempN.Z + cosAngle * _v.Z));

            SetModelViewMatrix();
        }

        public void Yaw(float angle)
        {
            var radian = angle.ToRadian();

            var cosAngle = Math.Cos(radian);
            var sinAngle = Math.Sin(radian);

            var tempU = new Vector3(_u);
            _u = new Vector3((float)(cosAngle * tempU.X - sinAngle * _n.X), (float)(cosAngle * tempU.Y - sinAngle * _n.Y), (float)(cosAngle * tempU.Z - sinAngle * _n.Z));
            _n = new Vector3((float)(sinAngle * tempU.X + cosAngle * _n.X), (float)(sinAngle * tempU.Y + cosAngle * _n.Y), (float)(sinAngle * tempU.Z + cosAngle * _n.Z));

            SetModelViewMatrix();
        }


    }
}
