using System.Collections.Generic;
using System.Linq;

namespace S3.Framework.Entities
{
    public class ObjDataModel
    {
        private string _useMtl;

        public List<Material> Materials { get; }
        public List<Vertex> Vertices { get; }
        public List<VertexTexture> VertexTextures { get; }
        public List<VertexNormal> VertexNormals { get; }
        public List<Face> Faces { get; }
        public Dimension_3D Dimension { get; private set; }

        public ObjDataModel()
        {
            Materials = new List<Material>();
            Vertices = new List<Vertex>();
            VertexNormals = new List<VertexNormal>();
            VertexTextures = new List<VertexTexture>();
            Faces = new List<Face>();

            Vertices.Add(new Vertex { Index = 0 });
            VertexTextures.Add(new VertexTexture { Index = 0 });
            VertexNormals.Add(new VertexNormal { Index = 0 });
            Faces.Add(new Face { Index = 0, UseMtl = string.Empty });
        }

        public void UpdateSize()
        {
            Dimension = new Dimension_3D
            {
                XMax = Vertices.Max(v => v.X),
                XMin = Vertices.Min(v => v.X),
                YMax = Vertices.Max(v => v.Y),
                YMin = Vertices.Min(v => v.Y),
                ZMax = Vertices.Max(v => v.Z),
                ZMin = Vertices.Min(v => v.Z)
            };
        }

        public void AddMaterials(List<Material> materials)
        {
            Materials.AddRange(materials);
        }

        public void AddVertex(Vertex v)
        {
            v.Index = Vertices.Count;
            Vertices.Add(v);
        }

        public void AddVertexNormal(VertexNormal vn)
        {
            vn.Index = VertexNormals.Count;
            VertexNormals.Add(vn);
        }

        public void AddVertexTextures(VertexTexture vt)
        {
            vt.Index = VertexTextures.Count;
            VertexTextures.Add(vt);
        }

        public void AddFace(Face face)
        {
            face.UseMtl = _useMtl;
            face.Index = Faces.Count;
            Faces.Add(face);
        }

        public void SetUseMtl(string useMtl)
        {
            _useMtl = useMtl;
        }

    }
}
