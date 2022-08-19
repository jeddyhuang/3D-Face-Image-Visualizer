using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace S3.UI.OpenTK.Primitives
{
    public class Cube : PolygonMesh
    {
        public Vector3 Center { get; set; }
        public float Length { get; set; }
        public Color Color { get; set; }

        private float? _radius;

        private float Radius
        {
            get
            {
                if (_radius == null)
                {
                    _radius = Length / 2.0f;
                }

                return _radius.Value;
            }
        }

        public Cube()
        {
            Center = new Vector3();
            Length = 0;
        }

        public override void Draw()
        {
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.Color3(Color);
            GL.Begin(PrimitiveType.Quads);

            //Front
            GL.Vertex3(Center.X - Radius, Center.Y + Radius, Center.Z + Radius);
            GL.Vertex3(Center.X - Radius, Center.Y - Radius, Center.Z + Radius);
            GL.Vertex3(Center.X + Radius, Center.Y - Radius, Center.Z + Radius);
            GL.Vertex3(Center.X + Radius, Center.Y + Radius, Center.Z + Radius);

            ////Left
            GL.Vertex3(Center.X - Radius, Center.Y + Radius, Center.Z - Radius);
            GL.Vertex3(Center.X - Radius, Center.Y - Radius, Center.Z - Radius);
            GL.Vertex3(Center.X - Radius, Center.Y - Radius, Center.Z + Radius);
            GL.Vertex3(Center.X - Radius, Center.Y + Radius, Center.Z + Radius);

            //Right
            GL.Vertex3(Center.X + Radius, Center.Y + Radius, Center.Z + Radius);
            GL.Vertex3(Center.X + Radius, Center.Y - Radius, Center.Z + Radius);
            GL.Vertex3(Center.X + Radius, Center.Y - Radius, Center.Z - Radius);
            GL.Vertex3(Center.X + Radius, Center.Y + Radius, Center.Z - Radius);

            //Back
            GL.Vertex3(Center.X + Radius, Center.Y - Radius, Center.Z - Radius);
            GL.Vertex3(Center.X + Radius, Center.Y + Radius, Center.Z - Radius);
            GL.Vertex3(Center.X - Radius, Center.Y + Radius, Center.Z - Radius);
            GL.Vertex3(Center.X - Radius, Center.Y - Radius, Center.Z - Radius);

            //Top
            GL.Vertex3(Center.X - Radius, Center.Y + Radius, Center.Z + Radius);
            GL.Vertex3(Center.X + Radius, Center.Y + Radius, Center.Z + Radius);
            GL.Vertex3(Center.X + Radius, Center.Y + Radius, Center.Z - Radius);
            GL.Vertex3(Center.X - Radius, Center.Y + Radius, Center.Z - Radius);

            //Bottom
            GL.Vertex3(Center.X - Radius, Center.Y - Radius, Center.Z + Radius);
            GL.Vertex3(Center.X + Radius, Center.Y - Radius, Center.Z + Radius);
            GL.Vertex3(Center.X + Radius, Center.Y - Radius, Center.Z - Radius);
            GL.Vertex3(Center.X - Radius, Center.Y - Radius, Center.Z - Radius);

            GL.End();
        }
    }


    public class CubeBuilder
    {
        private Cube _cube;

        public CubeBuilder New()
        {
            _cube = new Cube();
            return this;
        }

        public CubeBuilder WithCenter(Vector3 center)
        {
            _cube.Center = center;
            return this;
        }

        public CubeBuilder WithLength(float length)
        {
            _cube.Length = length;
            return this;
        }

        public CubeBuilder WithColor(Color color)
        {
            _cube.Color = color;
            return this;
        }

        public Cube Build()
        {
            return _cube;
        }
    }

}
