using S3.Framework.Entities;

namespace S3.ViewModels
{
    public class PositionVertexFaceViewModel
    {
        public Position Position { get; set; }
        public Vertex Vertex { get; set; }
        public Face Face { get; set; }

        public PositionVertexFaceViewModel(Position p, Vertex v, Face f)
        {
            Position = p;
            Vertex = v;
            Face = f;
        }

        public override string ToString()
        {
            return Position + " | " + Vertex + " | " + Face;
        }
    }
}
